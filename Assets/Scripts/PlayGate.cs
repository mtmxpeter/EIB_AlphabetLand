using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayGate : MonoBehaviour {

	private GameObject Boy;
	private GameObject Gate;
	Animator anim;
	public Animator animGate;
	public Animation animclip;
	public AudioClip[] list;
	AudioSource aud;
	AsyncOperation async;

	void Start () {
		Boy = GameObject.Find ("Boy");
		anim = Boy.GetComponent<Animator> ();
		anim.Play ("WalkToGate");	
		Gate = GameObject.Find ("Gate-door");
		animGate = Gate.GetComponent<Animator> ();
		aud = GetComponent<AudioSource> ();
		aud.loop = true;
		aud.clip = list [0];
		aud.Play();

	}


	public void Knock()
	{
		aud.loop = false;
		aud.clip = list [1];
		aud.Play();
	}

	public void OpenGate()
	{		
		
		aud.clip = list [2];
		aud.Play();
		animGate.Play ("Open");	
	}
}
