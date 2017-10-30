using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLetter : MonoBehaviour {

	CastleActions CA;

	// Use this for initialization
	void Start () {
		CA = GameObject.FindObjectOfType<CastleActions>();
		}
	
	// Letter Is Pressed
	void OnMouseDown() {
		CA.FindLetterPressed (gameObject.name);

	}
}
