using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CastleActions : MonoBehaviour {
	Animator anim;
	Animator lettersComeOut;
	Animator lettersanim;
	Animator letters2anim;
	Animator letters3anim;
	Animator CavalierAnim;
	Animator BoyAnim;

	public AudioClip abc;
	public AudioClip lets;
	public AudioClip sparkles;
	public AudioClip tryagain;
	public AudioSource aud;

	public GameObject door;
	public GameObject boy;
	public GameObject letters;
	public GameObject letters2;
	public GameObject letters3;
	public GameObject Cav;

	AudioSource doorsound;
	public GameObject Camera1OBJ,Camera2OBJ, Camera3OBJ, Camera4OBJ, Camera5OBJ, Camera6OBJ, Camera7OBJ,GUICameraOBJ;
	public Camera Cam1, Cam2, Cam3, Cam4, Cam5, Cam6, Cam7, GUICam;


	public int playingAudio = 0;
	public int LettersCount = 2;
	public int LettersClicked = 0;
	public int Current_group=1;
	public int[] Groups_count;

	public string[] LettersGroup1Array;
	public string[] LettersGroup2Array;
	public string[] LettersGroup3Array;
	public string[] LettersGroup4Array;

	public int FindLetterIndex = 0;
	public string CurrentLetter;


	public GameObject CardText;
	public GameObject CardText2;

	public GameObject CardLetters;
	public GameObject SelectedLetter;
	Vector3 pos;

	private int letterpressed;

	int GroupSel;
	int Group1Status;
	int Group2Status;
	int Group3Status;
	int Group4Status;
	int SafariStatus;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("CastleStatus", 1);
		aud = GetComponent<AudioSource>();
		door = GameObject.Find("CastleGate");
		boy = GameObject.Find("Boy");
		Cav = GameObject.Find("Cavalier");
		letters = GameObject.Find("Letters");
		letters2 = GameObject.Find("Letters2");


		letters3 = GameObject.Find("Letters3");
		letters3anim = letters3.GetComponent<Animator> ();

		lettersanim = letters2.GetComponent<Animator> ();
		anim = door.GetComponent<Animator> ();
		BoyAnim = boy.GetComponent<Animator> ();
		BoyAnim.Play ("Walk");
		CavalierAnim = Cav.GetComponent<Animator> ();
		doorsound = door.GetComponent<AudioSource>();

		Camera1OBJ = GameObject.Find("Cam1");
		Cam1 = Camera1OBJ.GetComponent<Camera>();
		Camera2OBJ = GameObject.Find("Cam2");
		Cam2 = Camera2OBJ.GetComponent<Camera>();
		Camera3OBJ = GameObject.Find("CavalierCam");
		Cam3 = Camera3OBJ.GetComponent<Camera>();
		Camera4OBJ = GameObject.Find("Cam4");
		Cam4 = Camera4OBJ.GetComponent<Camera>();
		Camera5OBJ = GameObject.Find("Cam5");
		Cam5 = Camera5OBJ.GetComponent<Camera>();
		Camera6OBJ = GameObject.Find("Cam6");
		Cam6 = Camera6OBJ.GetComponent<Camera>();
		Camera7OBJ = GameObject.Find("CavalierCam2");
		Cam7 = Camera7OBJ.GetComponent<Camera>();

		GUICameraOBJ = GameObject.Find("GUICam");
		GUICam = GUICameraOBJ.GetComponent<Camera>();
		CardText = GameObject.Find("CText");
		CardText2 = GameObject.Find("CText2");
		CardLetters = GameObject.Find("CardLetters");
		pos = CardLetters.transform.GetChild (0).transform.position;


		GroupSel = PlayerPrefs.GetInt ("GroupSelection");
		Group1Status = PlayerPrefs.GetInt ("Group1Status");
		Group2Status = PlayerPrefs.GetInt ("Group2Status");
		Group3Status = PlayerPrefs.GetInt ("Group3Status");
		Group4Status = PlayerPrefs.GetInt ("Group4Status");
		SafariStatus = PlayerPrefs.GetInt ("SafariStatus");


			if (GroupSel == 1) {
			ComeOut ();				
			}

		if (GroupSel == 2) {
				Group2_show ();
			}

			if (GroupSel == 3) {
				Group3_show ();
			}

			if (GroupSel == 4) {
				Group4_show ();
			}

	
		//Group1_show ();



	}


	void ComeOut () {

		aud.Play();
		StartCoroutine(playCastleDoor());	
	}


	IEnumerator playCastleDoor()
	{		
		yield return new WaitForSeconds(19);	
		doorsound.Play ();
		anim.Play ("Open");
		Invoke ("playLettersComeout", 2);
	}

	public void playLettersComeout()
	{
		aud.clip = abc;
		aud.Play ();
		lettersComeOut = letters.GetComponent<Animator> ();
		lettersComeOut.Play ("ComeOutofCastle");
	}


	public void Group1_show()
	{
		Current_group=1;
		Cam2.enabled = true;
		Cam1.enabled = false;
		lettersanim.Play ("LettersGroup1_show");
		aud.clip = lets;
		aud.Play ();
	}

	public void Group1_test()
	{				
		Cam2.enabled = true;
		Cam1.enabled = false;
		letters3anim.Play ("LettersGroup1_test");
		FindLetter();
	}


	public void Group2_show()
	{			
		LettersClicked = 0;
		Current_group=2;
		Cam4.enabled = true;
		Cam2.enabled = false;
		Cam1.enabled = false;
		lettersanim.Play ("LettersGroup2_show");
	}

	public void Group2_test()
	{				
		letters3anim.Play ("LettersGroup2_test");
		FindLetter();
	}

	public void Group3_show()
	{		
		Current_group=3;
		Cam5.enabled = true;
		Cam4.enabled = false;
		Cam2.enabled = false;
		Cam1.enabled = false;
		lettersanim.Play ("LettersGroup3_show");
	}

	public void Group3_test()
	{				
		letters3anim.Play ("LettersGroup3_test");
		FindLetter();
	}

	public void Group4_show()
	{		
		Current_group=4;
		Cam5.enabled = false;
		Cam6.enabled = true;
		Cam2.enabled = false;
		Cam4.enabled = false;
		lettersanim.Play ("LettersGroup4_show");
	}

	public void Group4_test()
	{				
		letters3anim.Play ("LettersGroup4_test");
		FindLetter();
	}

	public void FindLetter()
	{		
		if(Current_group==1){CurrentLetter = LettersGroup1Array [FindLetterIndex];} 
		if(Current_group==2){CurrentLetter = LettersGroup2Array [FindLetterIndex];} 
		if(Current_group==3){CurrentLetter = LettersGroup3Array [FindLetterIndex];} 
		if(Current_group==4){CurrentLetter = LettersGroup4Array [FindLetterIndex];} 
		letterpressed=0;
		aud.clip = Resources.Load("Audio/FindLetter/"+CurrentLetter) as AudioClip;
		FindLetterAudio();
	}

	public void FindLetterAudio()
	{		
		if (letterpressed == 0) {
			aud.Play ();
			Invoke ("FindLetterAudio", aud.clip.length + 2);
		}
	}

	public void FindLetterPressed(string name)
	{	
		letterpressed = 1;

		if (string.Compare (name, CurrentLetter) == 0) {
			
			aud.clip = Resources.Load("Audio/ConfLetter/"+CurrentLetter) as AudioClip;
			aud.Play();
			CavalierAnim.Play ("Clapping");
			Cav.GetComponent<AudioSource>().Play();
			Cam7.enabled = true;
			GUICam.enabled = true;
			Cam2.enabled = false;

			CardText.GetComponent<TextMesh> ().text = name.ToUpper();
			CardText2.GetComponent<TextMesh> ().text = name;
			SelectedLetter = CardLetters.transform.Find (name).gameObject;
			for (int i = 0; i < CardLetters.transform.childCount; i++) {

				CardLetters.transform.GetChild (i).transform.position = new Vector3 (-10, -10, -10);
			}		
			SelectedLetter.transform.position = pos;

			FindLetterIndex ++;
			float audl = aud.clip.length;
			if (audl < 7) {
				audl = 7;
			}
			Invoke ("resetCavCamera", audl);

		} 
		else {
			
			CavalierAnim.Play ("Shaking");
			aud.clip = tryagain;
			aud.Play ();
			Cam3.enabled = true;
			Cam2.enabled = false;
			Cam4.enabled = false;
			Cam5.enabled = false;
			Cam6.enabled = false;
			Cam7.enabled = false;
			Invoke("resetCavCamera", 4);
		}
	}

	public void resetCavCamera()
	{
		if (Current_group == 1) {
			Cam2.enabled = true;
			Cam3.enabled = false;
			Cam7.enabled = false;
		}
		if (Current_group == 2) {
			Cam4.enabled = true;
			Cam3.enabled = false;
			Cam7.enabled = false;
		}

		if (Current_group == 3) {
			Cam5.enabled = true;
			Cam3.enabled = false;
			Cam7.enabled = false;
		}

		if (Current_group == 4) {
			Cam6.enabled = true;
			Cam3.enabled = false;
			Cam7.enabled = false;
		}

		GUICam.enabled = false;

		if (FindLetterIndex == Groups_count[Current_group]) {
			if (Current_group == 1) {
				letters3anim.Play ("LettersGroup1Trans");
				PlayerPrefs.SetInt("Group1Status", 1);
				if (Group2Status != 1) {
					Invoke ("LoadMenu", 1);
				}
			}
			if (Current_group == 2) {
				letters3anim.Play ("LettersGroup2_trans");
				if (Group3Status != 1) {
					Invoke ("LoadMenu", 1);
				}
			}

			if (Current_group == 3) {
				letters3anim.Play ("LettersGroup3_trans");
				if (Group4Status != 1) {
					Invoke ("LoadMenu", 1);
				}

			}

			if (Current_group == 4) {
				letters3anim.Play ("LettersGroup4_trans");

			}

			FindLetterIndex = 0;
			aud.clip = sparkles;
			aud.Play ();
			Current_group ++;
			if (Current_group == 5) {
				if (SafariStatus == 1) {
					Invoke ("LoadSafari", 2);
				} else {
					Invoke ("LoadMenu", 2);
				}
			} else {
				Invoke ("Group" + Current_group + "_show", 2);
			}
		} else {
			FindLetter ();
		}
	}

	public void LoadSafari()
	{		
		SceneManager.LoadScene("Safari");  
	}

	public void LoadMenu()
	{		
		SceneManager.LoadScene("MainMenu");  
	}

}
