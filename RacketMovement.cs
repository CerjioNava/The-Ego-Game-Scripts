using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

	public GameObject Player1, Player2;

	private Touch touch;
	private Vector3 position, initialPos1, initialPos2, direction1, direction2, temp;


	void Awake() {

		initialPos1 = Player1.transform.position;
		initialPos2 = Player2.transform.position;

	}

	void Update () {
		
		RacketMoveTouch ();

	}


	void RacketMoveTouch () {

		if (Input.touchCount > 0) {

			for (int i = 0; i < Input.touchCount; ++i) {

				touch = Input.GetTouch (i);
				position = Camera.main.ScreenToWorldPoint (touch.position);
				position.z = 0f;

				if (position.x < 0f) {

					temp = Player1.transform.position;

					if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) 
						Player1.transform.position = position;
					else if (touch.phase == TouchPhase.Ended)
						Player1.transform.position = initialPos1;

					if (Player1.transform.position != temp)
						direction1 = Player1.transform.position - temp;

				} else {

					temp = Player2.transform.position;

					if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
						Player2.transform.position = position;
					else if (touch.phase == TouchPhase.Ended)
						Player2.transform.position = initialPos2;

					if (Player2.transform.position != temp)
						direction2 = Player2.transform.position - temp;

				}

			}

		}

	}


	void RacketMoveMouse () {

		if (Input.GetButton ("Fire1") || Input.GetButton ("Fire2")) {
			
			position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			position.z = 0f;

		}


		temp = Player1.transform.position;

		if (position.x < 0f && Input.GetButton ("Fire1")) 
			Player1.transform.position = position;
		else 
			Player1.transform.position = initialPos1;

		if (Player1.transform.position != temp)
			direction1 = Player1.transform.position - temp;


		temp = Player2.transform.position;

		if (position.x > 0f && Input.GetButton ("Fire2")) 
			Player2.transform.position = position;
		else
			Player2.transform.position = initialPos2;

		if (Player2.transform.position != temp)
			direction2 = Player2.transform.position - temp;
		
	}


	public Vector3 GetDirection (int n){

		if (n == 1) {

			direction1 = direction1 / Mathf.Sqrt ( Mathf.Pow (direction1.x, 2) + Mathf.Pow (direction1.y, 2) );
			return direction1;

		} else {
		
			direction2 = direction2 / Mathf.Sqrt ( Mathf.Pow (direction2.x, 2) + Mathf.Pow (direction2.y, 2) );
			return direction2;		

		}

	}

}
