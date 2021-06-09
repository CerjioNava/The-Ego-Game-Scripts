using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundGallery : MonoBehaviour {

	private int sound;

	public void PlaySound (int index) {

		if (sound != index) {

			FindObjectOfType<AudioManager> ().StopAudio ("Sound" + sound.ToString ());	
			GameObject.Find ("Sound" + sound).GetComponent<Image>().color = new Color32 (255, 255, 255, 150);

		}

		FindObjectOfType<AudioManager> ().PlayAudio ("Sound" + index.ToString ());
		GameObject.Find ("Sound" + index).GetComponent<Image>().color = new Color32 (255, 255, 255, 255);
		sound = index;

	}

	public void BackToMenu () {

		FindObjectOfType<AudioManager> ().EgoTheme (1f);
		SceneManager.LoadScene (0);

	}


}
