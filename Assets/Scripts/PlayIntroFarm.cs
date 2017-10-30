using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIntroFarm : MonoBehaviour {
	Animator anim;
	public AudioClip ac;
	AudioSource aud;
	private GameObject tractor;
	private Animator tractoranim;

	// Use this for initialization
	void Start () {		
		aud = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		tractor = GameObject.Find ("Tractor");
		aud.Play();
		StartCoroutine(playCameraAnim());

		}
	
	IEnumerator playCameraAnim()
	{
		
		yield return new WaitForSeconds(10);
		anim.Play("FlyBy");
		//audio.clip = ac;
		//audio.Play ();
		anim = tractor.GetComponent<Animator> ();
		anim.Play ("Move");
	}
}
