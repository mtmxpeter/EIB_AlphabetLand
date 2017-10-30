using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class testscript : MonoBehaviour {
	AsyncOperation async;
	// Use this for initialization
	void Start () {
		//Invoke ("ActivateScene", 8);
		//StartCoroutine("load");
	}

	IEnumerator load() {
		Debug.Log ("async");
		async = SceneManager.LoadSceneAsync("Castle");
		async.allowSceneActivation = false;
		yield return async;

	}

	public void ActivateScene() {
		async.allowSceneActivation = true;
	}
}
