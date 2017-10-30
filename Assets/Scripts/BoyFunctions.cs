using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class BoyFunctions : MonoBehaviour {

	public PlayGate PG;
	public PlayLanding PL;
	AsyncOperation async;
	int boyClicked = 0;

	void Start () {
		PG = GameObject.FindObjectOfType<PlayGate>();
		PL = GameObject.FindObjectOfType<PlayLanding>();
		Scene scene = SceneManager.GetActiveScene();

	}
	
	void Knock()
	{
		PG.Knock ();
		async = SceneManager.LoadSceneAsync("Castle");
		async.allowSceneActivation = false;
	}

	void Open()
	{
		PG.OpenGate ();
	}

	void Hide()
	{
		PL.BoyHide ();
	}

	void LoadCastle()
	{
		//SceneManager.LoadScene("Castle");  
		async.allowSceneActivation = true;
	}

	void OnMouseDown() {

		boyClicked ++;
		if (boyClicked == 3) {
			async = SceneManager.LoadSceneAsync("MainMenu");
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}


}
