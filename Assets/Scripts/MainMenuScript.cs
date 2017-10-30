using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  


public class MainMenuScript : MonoBehaviour {

	public Button FarmButton, SafariButton, CastleButton1, CastleButton2, CastleButton3, CastleButton4, LandingButton;
	public Sprite SafariImg1, SafariImg2,LandingImg1, LandingImg2, Group1Img1, Group1Img2, Group2Img1, Group2Img2, Group3Img1, Group3Img2, Group4Img1, Group4Img2;
	public GameObject MainPanel, PurchasePanel, PurchaseConfirmation, PurchaseCastlePanel, PurchaseCastleConfirmation, ScrollerPanel, Arrow;

	private int FarmStatus, CastleStatus, SafariStatus, Group1Status, Group2Status,Group3Status,Group4Status;

	AsyncOperation async;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("GroupSelection", 1);
	
		FarmButton = GameObject.Find ("FarmButton").GetComponent<Button> ();
		SafariButton = GameObject.Find ("SafariButton").GetComponent<Button> ();
		CastleButton1 = GameObject.Find ("CastleButton1").GetComponent<Button> ();
		CastleButton2 = GameObject.Find ("CastleButton2").GetComponent<Button> ();
		CastleButton3 = GameObject.Find ("CastleButton3").GetComponent<Button> ();
		CastleButton4 = GameObject.Find ("CastleButton4").GetComponent<Button> ();
		LandingButton = GameObject.Find ("LandingButton").GetComponent<Button> ();
		MainPanel = GameObject.Find ("MainPanel");
		PurchasePanel = GameObject.Find ("PurchasePanel");
		PurchaseConfirmation = GameObject.Find ("PurchaseConfirmation");
		PurchaseCastlePanel = GameObject.Find ("PurchaseCastlePanel");
		PurchaseCastleConfirmation = GameObject.Find ("PurchaseCastleConfirmation");
		Arrow = GameObject.Find ("Arrow");


		PurchasePanel.SetActive (false);
		PurchaseConfirmation.SetActive (false);
		PurchaseCastlePanel.SetActive (false);
		PurchaseCastleConfirmation.SetActive (false);
		FarmStatus = PlayerPrefs.GetInt ("FarmStatus");
		CastleStatus = PlayerPrefs.GetInt ("CastleStatus");
		SafariStatus = PlayerPrefs.GetInt ("SafariStatus");

		Group1Status = PlayerPrefs.GetInt ("Group1Status");
		Group2Status = PlayerPrefs.GetInt ("Group2Status");
		Group3Status = PlayerPrefs.GetInt ("Group3Status");
		Group4Status = PlayerPrefs.GetInt ("Group4Status");

		if (SafariStatus == 1) {
			SafariButton.image.overrideSprite = SafariImg1;
			SafariButton.interactable = true;
		} else {
			SafariButton.image.overrideSprite = SafariImg2;

		}

		if (FarmStatus == 1) {
			CastleButton1.image.overrideSprite = Group1Img1;
			CastleButton1.interactable = true;

			LandingButton.image.overrideSprite = LandingImg1;
			LandingButton.interactable = true;
		} else {
			LandingButton.image.overrideSprite = LandingImg2;
			LandingButton.interactable = false;

			CastleButton1.image.overrideSprite = Group1Img2;
			CastleButton1.interactable = false;
		}

		if (Group1Status == 1) {
			CastleButton2.image.overrideSprite = Group2Img1;
		} else {
			CastleButton2.image.overrideSprite = Group2Img2;
			CastleButton2.interactable = false;
		}

		if (Group3Status == 1) {
			CastleButton3.image.overrideSprite = Group3Img1;
		}
		if (Group4Status == 1) {
			CastleButton4.image.overrideSprite = Group4Img1;
		}

	}
	public void PressFarmButton() {
		SceneManager.LoadScene ("Farm");
	}

	public void PressCastleButton(int group) {		
		PlayerPrefs.SetInt("GroupSelection", group);

		if (group == 1 || group==2) {
			SceneManager.LoadScene ("Castle");
		}


		if (group == 3) {
			if (Group3Status == 1) {
				SceneManager.LoadScene ("Castle");
			} else {
				PurchaseCastlePanel.SetActive (true);
				MainPanel.SetActive (false);
			}
		}
		if (group == 4) {
			if (Group4Status == 1) {
				SceneManager.LoadScene ("Castle");
			} else {
				PurchaseCastlePanel.SetActive (true);
				MainPanel.SetActive (false);
			}
		}
	}

	public void PressLandingButton() {
		SceneManager.LoadScene ("Landing");
	}


	public void PressSafariButton()
	{	
		if (PlayerPrefs.GetInt ("SafariStatus") == 1) {
			SceneManager.LoadScene ("Safari");
		} else {
			PurchasePanel.SetActive (true);
			MainPanel.SetActive (false);
		}
	}

	public void ConfirmSafari()
	{		
		
		PurchaseConfirmation.SetActive(true);
		MainPanel.SetActive(false);
		PurchasePanel.SetActive(false);
	}

	public void ConfirmCastle()
	{		
		Debug.Log ("Conf Castle");
		PurchaseCastleConfirmation.SetActive(true);
		MainPanel.SetActive(false);
		PurchaseCastlePanel.SetActive(false);
	}


	public void PressReturnButton()
	{
		PurchasePanel.SetActive(false);
		PurchaseConfirmation.SetActive(false);
		PurchaseCastlePanel.SetActive(false);
		PurchaseCastleConfirmation.SetActive(false);
		MainPanel.SetActive(true);
	}




	public void PlaySafari()
	{
		SceneManager.LoadScene ("Safari");
	}

	public void PlayCastle()
	{
		SceneManager.LoadScene ("Castle");
	}

	public void HideArrow()
	{
		Arrow.SetActive (false);
	}
}
