using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class ParachuteActions : MonoBehaviour {

	GameObject Boy;
	GameObject Cav;
	Animator anim;
	Animator animCav;
	AudioSource aud;
	AsyncOperation async;

	void Start () {
		Boy = GameObject.Find ("Boy");
		anim = Boy.GetComponent<Animator> ();
		anim.Play ("Parachute");	

		Cav = GameObject.Find ("Cavalier");
		animCav = Cav.GetComponent<Animator> ();
		animCav.Play ("CavalierDropOff");	
		aud = GetComponent<AudioSource> ();
		aud.Play ();
		async = SceneManager.LoadSceneAsync("Gate");
		async.allowSceneActivation = false;
		Invoke("LoadGate", aud.clip.length);
	}
	
	public void LoadGate()
	{		
		//SceneManager.LoadScene("Gate");  
		async.allowSceneActivation = true;
	}
}
