using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Smack : MonoBehaviour {

	public GameObject ego, smashText, restart, spank1, spank2;
	public Text contador;
	public Image smashPower;

	public int hits, time;

	private Vector3 scale, initScale;
	private bool conteo;

	private Vector2 randomDirection;

	void Awake () {

		hits = 0;
		time = 10;
		contador.text = time.ToString ();
		conteo = false;
		Invoke ("Idle", 6.5f); 
		initScale = ego.GetComponent <RectTransform> ().localScale;

	}

	void Update () {

		if (ego.GetComponent <BoxCollider2D>().IsTouchingLayers (LayerMask.GetMask ("Walls")))
			FindObjectOfType<AudioManager> ().PlayAudio ("Smack" + Random.Range (1, 21).ToString ());

	}

	void Idle () {
		GetComponent<Animator> ().SetBool ("Idle", true);
	}

	public void SmackTheEgo () {

		if (!conteo) {

			conteo = true;
			InvokeRepeating ("Contador", 1f, 1f);
			smashText.GetComponent<Animator> ().SetBool ("NotIdle", true);

		}

		FindObjectOfType<AudioManager> ().PlayAudio ("Smack" + Random.Range (1, 21).ToString ());
		hits++;

		smashPower.fillAmount = (float) hits / 60f;

		scale = ego.GetComponent <RectTransform> ().localScale;
		scale.x += 0.01f;
		scale.y += 0.01f;
		ego.GetComponent <RectTransform> ().localScale = scale;


		SpankEnable ();

	}

	void SpankEnable () {

		CancelInvoke ("SpankDisable");
		spank1.SetActive (true);
		Invoke ("SpankDisable", 0.25f);
	}


	void SpankDisable () {

		spank1.SetActive (false);
		spank2.SetActive (false);

	}

	void Contador() {

		time--;
		contador.text = time.ToString ();

		if (time == 0) {

			Special ();
			CancelInvoke ("Contador");

		}

	}

	void Special () {

		GetComponent<Animator> ().SetBool ("Special", true);
		FindObjectOfType<AudioManager> ().PlayAudio ("BringMe" + Random.Range (1, 4).ToString ());
		Invoke ("CancelSpecial", 1.8f);
		Invoke ("Smash", 2f); 

	}

	void CancelSpecial () {
		GetComponent<Animator> ().SetBool ("Special", false);
	}

	void Smash () {

		spank2.SetActive (true);
		Invoke ("SpankDisable", 0.25f);

		FindObjectOfType<AudioManager> ().PlayAudio ("Placata" + Mathf.Round (smashPower.fillAmount*3));

		randomDirection = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
		randomDirection = randomDirection / Mathf.Sqrt ( Mathf.Pow (randomDirection.x, 2) + Mathf.Pow (randomDirection.y, 2) );

		ego.GetComponent<Rigidbody2D>().velocity = randomDirection * 3000f * smashPower.fillAmount;
		ego.GetComponent<Rigidbody2D> ().angularVelocity = Random.Range (600, 1000);

		Invoke ("ActiveAgain", 2f); 

	}

	void ActiveAgain() {
		restart.SetActive (true);
	}

	public void Again () {

		restart.SetActive (false);

		ego.GetComponent <RectTransform> ().localScale = initScale;
		ego.GetComponent <RectTransform> ().anchoredPosition = Vector3.zero;
		ego.GetComponent <RectTransform> ().rotation = new Quaternion (0f, 0f, 0f, 1f);

		ego.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		ego.GetComponent<Rigidbody2D> ().angularVelocity = 0f;

		conteo = false;
		hits = 0;
		time = 10;
		smashPower.fillAmount = 0f;
		contador.text = time.ToString ();

		smashText.GetComponent<Animator> ().SetBool ("NotIdle", false);

	}



	public void BackToMenu () {

		FindObjectOfType<AudioManager> ().EgoTheme (1f);
		SceneManager.LoadScene (0);

	}

}
