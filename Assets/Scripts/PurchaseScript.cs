﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  


public class PurchaseScript : MonoBehaviour, IStoreListener
{
	private static IStoreController m_StoreController;          // The Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.		

	public static string PRODUCT_SAFARI = "safariscene";

	public static string PRODUCT_LEVEL3 = "allevel3";
	public static string PRODUCT_LEVEL4 = "allevel4";


	private int castlelevel;



	// Apple App Store-specific product identifier for the subscription product.
	//private static string kProductNameAppleSubscription =  "com.unity3d.subscription.new";

	public MainMenuScript MMS;

	void Start()
	{

		//MMS = GameObject.FindObjectOfType<MainMenuScript>();
		// If we haven't set up the Unity Purchasing reference
		if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
	}

	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}


		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		builder.AddProduct(PRODUCT_SAFARI, ProductType.NonConsumable);			
	
		builder.AddProduct(PRODUCT_LEVEL3, ProductType.NonConsumable);			
		builder.AddProduct(PRODUCT_LEVEL4, ProductType.NonConsumable);		


		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}



	public void BuySafariScene()
	{
		// Buy the non-consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(PRODUCT_SAFARI);

	}

	public void BuyCastleLevel()
	{
		// Buy the non-consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.

		castlelevel = PlayerPrefs.GetInt("GroupSelection");

		if (castlelevel == 3) {
			BuyProductID (PRODUCT_LEVEL3);
		}
		if (castlelevel == 4) {
			BuyProductID (PRODUCT_LEVEL4);
		}

	}


	void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference with the general product identifier and the Purchasing 
			// system's products collection.
			Product product = m_StoreController.products.WithID(productId);

			// If the look up found a product for this device's store and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
				// asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report the product look-up failure situation  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
			// retrying initiailization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}


	// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
	// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");

			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
			// the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then 
				// no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}


	//  
	// --- IStoreListener
	//

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_SAFARI, StringComparison.Ordinal))
		{
			Debug.Log("Safari Purchase Successful");	
				PlayerPrefs.SetInt ("SafariStatus", 1);
				//MMS.ConfirmSafari ();

			SceneManager.LoadScene ("Safari");
		}

		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_LEVEL3, StringComparison.Ordinal)) {
			Debug.Log ("Purchase Level 3 Successful");	
			PlayerPrefs.SetInt ("Group3Status", 1);
			//MMS.ConfirmCastle ();
			SceneManager.LoadScene ("Castle");
		}
		if (String.Equals (args.purchasedProduct.definition.id, PRODUCT_LEVEL4, StringComparison.Ordinal)) {
			Debug.Log ("Purchase Level 4 Successful");	
			PlayerPrefs.SetInt ("Group4Status", 1);
			//MMS.ConfirmCastle ();
			SceneManager.LoadScene ("Castle");
		}

	

		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}


}


