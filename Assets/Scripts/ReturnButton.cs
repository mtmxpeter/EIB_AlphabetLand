using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class ReturnButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void ReturnMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
