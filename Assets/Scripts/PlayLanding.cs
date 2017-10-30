using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLanding : MonoBehaviour {
	
	private GameObject cav;

	public Camera[] cams;
	Animator anim;
	Animation animclip;
	public AudioClip[] list;
	AudioSource aud;
	AudioSource boyaud;

	public GameObject Camera1OBJ;
	public GameObject Camera2OBJ;
	public Camera Cam1;
	public Camera Cam2;

	public GameObject boy;
	Animator boyanim;
	public Renderer rend;

	void Start () {
		cav = GameObject.Find ("Cavalier");
		anim = cav.GetComponent<Animator> ();
		anim.Play ("Landing");	
		aud = GetComponent<AudioSource> ();
		aud.clip = list [0];
		aud.Play();
		boy = GameObject.Find ("Boy");
		boyaud = boy.GetComponent<AudioSource> ();
		rend = boy.GetComponent<Renderer>();

		Camera1OBJ = GameObject.Find("Cam1");
		Cam1 = Camera1OBJ.GetComponent<Camera>();
		Camera2OBJ = GameObject.Find("Cam2");
		Cam2 = Camera2OBJ.GetComponent<Camera>();	

	}
	
	public void CloseUp()
	{
		Cam2.enabled = true;
		Cam1.enabled = false;
		aud.clip = list [1];
		aud.Play();	
	}

	public void BoyWalk()
	{
		boyanim = boy.GetComponent<Animator> ();
		boyanim.Play ("WalkToPlane");	
		boyaud.Play();	
	}

	public void BoyHide()
	{
		boy.SetActive(false);
	}

	public void StartEngines()
	{
		aud.clip = list [2];
		aud.Play();	
	}
}
