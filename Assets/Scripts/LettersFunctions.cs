using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersFunctions : MonoBehaviour {
	public CastleActions CA;

	void Start () {
		CA = GameObject.FindObjectOfType<CastleActions>();

	}
	

	public void Stage1()
	{
		CA.Group1_show ();
	}
}
