using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class FarmMenu : MonoBehaviour {
	public GameObject Panel;

	// Use this for initialization
	void Start () {

	}
	
	public void PlayFarmAgain()
	{
		Panel.SetActive (false);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
