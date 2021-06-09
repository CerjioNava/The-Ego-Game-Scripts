using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject CharacterSelection;

	void Awake () {

		Invoke ("Idle", 5.5f);

	}

	void Idle() {

		GetComponent<Animator> ().SetBool ("Idle", true);

	}


	public void PlayGame (int n) {

		FindObjectOfType<AudioManager> ().EgoTheme (1 / (float)n);

		if (n == 1) {
		
			CharacterSelection.SetActive (true);
			FindObjectOfType<AudioManager> ().EgoTheme (0.5f);

		} else if (n == 2) {

			FindObjectOfType<AudioManager> ().EgoTheme (0.5f);
			SceneManager.LoadScene (n);

		} else if (n == 3) {

			FindObjectOfType<AudioManager> ().EgoTheme (0.15f);
			SceneManager.LoadScene (n);

		}

	}

	public void QuitButton () {
	
		Application.Quit ();

	}

}
