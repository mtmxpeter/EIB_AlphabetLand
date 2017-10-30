using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AnimalTalk : MonoBehaviour {

	AudioSource ac;
	Animator anim;
	private MainScript MS;
	public int Animalclicked;
	public Scene scene;


	// Use this for initialization
	void Start () {
		ac = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		Animalclicked = 0;
		scene = SceneManager.GetActiveScene();	
	}

	void Awake()
	{
		MS = GameObject.FindObjectOfType<MainScript>();
	}

	// Update is called once per frame
	void Update () {
		

		}
	void OnMouseDown() {
		if (MS.playingAudio == 0) {
			ac.PlayOneShot (ac.clip);
			anim.Play ("Talk");
			MS.setPlayingAudio ();
			Animalclicked = 1;
			Invoke("resetAudio", ac.clip.length);

		}
	}

	void resetAudio()
	{
		MS.playingAudio = 0;
		if (scene.name == "Farm") {
			if (MS.totalClicked == 8) {
				MS.totalClicked = 0;
				PlayerPrefs.SetInt ("FarmStatus", 1);
				SceneManager.LoadScene ("Landing"); 
				//MS.ShowFarmPanel ();
			}
		}

		if (scene.name == "Safari") {
			
			if (MS.totalClicked == 5) {	
				MS.totalClicked = 0;
				SceneManager.LoadScene ("MainMenu");  

			}
		}
	}
}
