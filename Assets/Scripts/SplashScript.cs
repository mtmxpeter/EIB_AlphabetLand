using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SplashScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadFarm",3);
	}
	
	public void LoadFarm()
	{		
		SceneManager.LoadScene("MainMenu");  
	}
}
