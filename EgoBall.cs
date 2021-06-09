using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgoBall : MonoBehaviour {

	public GameObject effect;

	private Vector3 initPosition;

	public float rage;
	public int turno, maxTurno;

	private int hits, score1, score2;
	private bool hit1, hit2;

	private Rigidbody2D rb;
	private Animator anim;

	void Awake () {

		initPosition = transform.position;

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		MaxTurno (2);

		InitialProperties ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collision) {

		if (GetComponent <CircleCollider2D> ().IsTouchingLayers (LayerMask.GetMask ("Player"))) {

			if (collision.gameObject.name.StartsWith ("Collider1") && !hit1) {
			
				rb.velocity = FindObjectOfType<Directions> ().GetDirection ("Right", hits) * rage;
				hit1 = true;
				hit2 = false;
				FindObjectOfType<AudioManager> ().PlayAudio ("Marico1");

			} else if (collision.gameObject.name.StartsWith ("Collider2") && !hit2) {
				
				rb.velocity = FindObjectOfType<Directions> ().GetDirection ("Left", hits) * rage;
				hit1 = false;
				hit2 = true;
				FindObjectOfType<AudioManager> ().PlayAudio ("Marico2");

			}

			Instantiate (effect, transform.position, transform.rotation);

			anim.SetBool ("RotateRight", hit1);
			anim.SetBool ("RotateLeft", hit2);

			if (hits == 0)
				hits++;

			rage += 0.5f;

		} 

		if (GetComponent <CircleCollider2D> ().IsTouchingLayers (LayerMask.GetMask ("Walls"))) {


			if (hit1) 
				FindObjectOfType<Score> ().SetScore (1);
			else if (hit2) 
				FindObjectOfType<Score> ().SetScore (2);

			rb.velocity = Vector2.zero;
			InitialProperties ();
			transform.position = initPosition;
						
		}			

	}

	void InitialProperties () {

		rage = 12f;
		hits = 0;
		hit1 = false;
		hit2 = false;
		anim.SetBool ("RotateRight", hit1);
		anim.SetBool ("RotateLeft", hit2);

		if (turno >= maxTurno) {

			turno = 0;
			initPosition.x *= -1;

		}

		turno++;

	}

	public void MaxTurno (int n) {
		maxTurno = n;
	}

}

