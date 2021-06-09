using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public GameObject[] Characters;
	public Image [] pictures;
	public GameObject border1, border2;
	public Text	playerSelection, selectAgain;
	public Image selectButton;

	public int select1, select2, sound;

	public bool ready1, ready2;


	void Awake () {

		select1 = 0;
		select2 = 0;

		ready1 = false;
		ready2 = false;

		border1.SetActive (false);
		border2.SetActive (false);

		playerSelection.text = "Select Player 1";
		playerSelection.color = new Color32 (255, 255, 0, 255);

		selectButton.color = new Color32 (255, 255, 0, 255);
		selectAgain.text = "SELECT";

	}

	public void SelectCharacter (int n) {
			

		if (!ready1) {

			pictures[n].color = new Color32 (255, 255, 255, 255);

			if (!border1.activeSelf)
				select1 = n;

			border1.SetActive (true);
			border1.transform.position = Characters [n].transform.position;
		
			if (select1 != n)
				pictures[select1].color = new Color32 (255, 255, 255, 150);

			select1 = n;

			PlayAudio (n);

		} else if (!ready2) {

			pictures[n].color = new Color32 (255, 255, 255, 255);

			if (!border2.activeSelf)
				select2 = n;

			border2.SetActive (true);
			border2.transform.position = Characters [n].transform.position;
		
			if (select2 != n)
				pictures[select2].color = new Color32 (255, 255, 255, 150);

			select2 = n;

			PlayAudio (n);

		}

	}

	void PlayAudio (int n) {

		if (sound != n)
			FindObjectOfType<AudioManager> ().StopAudio ("Character" + sound.ToString ());	

		FindObjectOfType<AudioManager> ().PlayAudio ("Character" + n.ToString ());

		sound = n;

	}

	public void BackToMenu () {

		gameObject.SetActive (false);
		FindObjectOfType<AudioManager> ().EgoTheme (1);

	}

	public void Ready () {

		if (!ready1 && border1.activeSelf) {

			ready1 = true;
			FindObjectOfType<Selection> ().CharacterSelect (1, pictures [select1].sprite);
			playerSelection.text = "Select Player 2";
			playerSelection.color = new Color32 (0, 180, 255, 255);
			selectButton.color = new Color32 (0, 180, 255, 255);

		} else if (!ready2 && border2.activeSelf)  {

			ready2 = true;
			FindObjectOfType<Selection> ().CharacterSelect (2, pictures [select2].sprite);
			playerSelection.color = new Color32 (255, 0, 0, 255);
			playerSelection.text = "EGO TIME!";
			selectButton.color = new Color32 (255, 0, 0, 255);
			selectAgain.text = "CHANGE";

		} else if (ready1 && ready2) {

			pictures[select1].color = new Color32 (255, 255, 255, 150);
			pictures[select2].color = new Color32 (255, 255, 255, 150);

			Awake ();

		}

	}

	public void Play () {

		if (ready1 && ready2) {
		
			FindObjectOfType<Selection> ().PlayerNumbers (select1, select2);
			FindObjectOfType<AudioManager> ().EgoTheme (0.5f);
			SceneManager.LoadScene (1);

		}
	}

}
