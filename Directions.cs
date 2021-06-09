using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions : MonoBehaviour {

	public Transform[] directions;
	public GameObject egoBall;
	private Vector3 direction3D;
	public Vector3 racket;
	private Vector2 direction2D;
	private int randomDirection;

	void Awake () {

		direction2D = Vector2.zero;

	}

	public Vector2 GetDirection (string LeftRight, int hit) {

		if (LeftRight == "Left") {

			if (hit != 0)
				randomDirection = Random.Range (1, 6);
			else {

				racket = FindObjectOfType<RacketMovement> ().GetDirection (2);

				if (racket.y < -0.35f)
					randomDirection = 5;
				else if (racket.y > 0.35f)
					randomDirection = 1;
				else
					randomDirection = 3;

			}
		
		} else {
		
			if (hit != 0)
				randomDirection = Random.Range (6, 11);
			else {

				racket = FindObjectOfType<RacketMovement> ().GetDirection (1);

				if (racket.y < -0.35f)
					randomDirection = 6;
				else if (racket.y > 0.35f)
					randomDirection = 10;
				else
					randomDirection = 8;

			}

		}

		direction3D = directions [randomDirection - 1].position - egoBall.transform.position;
		direction2D = new Vector2 (direction3D.x, direction3D.y);
		direction2D = direction2D / Mathf.Sqrt ( Mathf.Pow (direction2D.x, 2) + Mathf.Pow (direction2D.y, 2) );

		return direction2D;

	}


}
