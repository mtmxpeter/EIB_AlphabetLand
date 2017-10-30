using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressLetter : MonoBehaviour {
	//public Material semi;

	public GameObject Letters;
	public GameObject Letters2;
	public GameObject CardText;
	public GameObject CardText2;
	public GameObject GuiCam;
	public GameObject CardLetters;
	public GameObject SelectedLetter;
	public Camera Gcam;
	Animator Letters2Anim;
	public string objectName;
	AudioSource ac;
	CastleActions CA;
	Renderer rend;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		ac = GetComponent<AudioSource> ();
		CA = GameObject.FindObjectOfType<CastleActions>();
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		CardText = GameObject.Find("CText");
		CardText2 = GameObject.Find("CText2");
		CardLetters = GameObject.Find("CardLetters");
		Letters = GameObject.Find("Letters");
		Letters2 = GameObject.Find("Letters2");

		GuiCam = GameObject.Find("GUICam");
		Gcam = GuiCam.GetComponent<Camera>();
		objectName = gameObject.name;

		pos = CardLetters.transform.GetChild (0).transform.position;
	

	}

	// Letter Is Pressed
	void OnMouseDown() {
		if (CA.playingAudio == 0) {
			CA.playingAudio = 1;
			CA.LettersClicked += 1;
			ac.Play ();		
			Material newMat = Resources.Load ("Letters2", typeof(Material)) as Material;
			rend.sharedMaterial = newMat;
			CardText.GetComponent<TextMesh> ().text = objectName.ToUpper();
			CardText2.GetComponent<TextMesh> ().text = objectName;

			Gcam.enabled = true;
			SelectedLetter = CardLetters.transform.Find (objectName).gameObject;
			for (int i = 0; i < CardLetters.transform.childCount; i++) {
				
				CardLetters.transform.GetChild (i).transform.position = new Vector3 (-10, -10, -10);
			}
			//Debug.Log (pos);
			SelectedLetter.transform.position = pos;
			Invoke ("resetAudio", ac.clip.length);
		}
	}

	void resetAudio()
	{
		
		CA.playingAudio = 0;	
		Gcam.enabled = false;
	
		if (CA.LettersClicked == CA.Groups_count[CA.Current_group]) {		
			CA.LettersClicked = 0;	
			Letters2Anim = Letters2.GetComponent<Animator> ();
			Letters2Anim.Play ("LettersIdle");

			//CA.FindLetter ();
			//Invoke("CA.Group" +CA.Current_group+ "_test", 0);
			if (CA.Current_group == 1) 
			{				
				CA.Group1_test ();			
			}
			if (CA.Current_group == 2)
			{
				CA.Group2_test ();
			}
			if (CA.Current_group == 3)
			{
				CA.Group3_test ();
			}
			if (CA.Current_group == 4)
			{
				CA.Group4_test ();
			}
		}

	}
}
