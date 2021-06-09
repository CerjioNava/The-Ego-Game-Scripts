using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public int index;

	public Sound[] sounds;

	public static AudioManager instance;

	private float volume;

	private Sound stage;

	void Awake () {
	
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {

			s.source = gameObject.AddComponent <AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.spatialBlend = s.spatialBlend;
			s.source.loop = s.loop;
		
		}

	}

	void Start () {

		PlayAudio ("Ego Song");
		EgoTheme (1f);		

	}



	public Sound GetAudio (string audioName) {

		Sound s = Array.Find (sounds, sound => sound.audioName == audioName);
		return s;

	}

	public void PlayAudio (string audioName) {

		Sound s = GetAudio (audioName);

		if (s == null)
			return;

		s.source.Play ();

	}

	public void StopAudio (string audioName) {

		Sound s = GetAudio (audioName);

		if (s == null)
			return;

		s.source.Stop ();

	}

	public void AudioVolume (string audioName, float volume) {

		Sound s = GetAudio (audioName);
		s.source.volume = volume;

	}

	public void EgoTheme (float volume) {

		AudioVolume ("Ego Song", volume);
						
	}


}
