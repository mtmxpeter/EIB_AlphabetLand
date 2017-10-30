using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CavalierActions : MonoBehaviour {
	private PlayLanding PL;
	private Animator anim;
	private Animation animclip;
	// Use this for initialization
	void Start () {
		PL = GameObject.FindObjectOfType<PlayLanding>();
		anim = GetComponent<Animator> ();

	}

	public void GroundAnimation()
	{
		PL.CloseUp ();
		anim.Play ("Ground");

	}

	public void BoyAnimation()
	{
		PL.BoyWalk ();
	}

	public void LoadParachute()
	{		
		SceneManager.LoadScene("Parachute");  
	}

	public void StartEngines()
	{
		PL.StartEngines ();
	}

}
