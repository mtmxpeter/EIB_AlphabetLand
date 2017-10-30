using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MainScript : MonoBehaviour {
	public int playingAudio = 0;
	public int totalClicked;
	public GameObject Panel;

	void Start () {
		Panel= GameObject.Find ("Panel");
		Panel.SetActive (false);
	}

	public void setPlayingAudio()
	{
		if (playingAudio == 0) {
			playingAudio = 1;
		}		

		var objects = GameObject.FindGameObjectsWithTag("Animal");
		var objectCount = objects.Length;
		totalClicked = 1;
		foreach (var obj in objects) {			
			Debug.Log(obj.name + " /" + obj.GetComponent<AnimalTalk>().Animalclicked);
			totalClicked += obj.GetComponent<AnimalTalk> ().Animalclicked;
			Debug.Log ("Total clicked" + totalClicked);
		}


	}

	public void PlayFarmAgain()
	{
		Panel.SetActive (false);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void ShowFarmPanel()
	{
		Panel.SetActive (true);
	}
}
