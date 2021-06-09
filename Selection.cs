using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour {
	
	public Sprite character1, character2;

	public int player1, player2;

	void Awake () {

		DontDestroyOnLoad (gameObject);

	}
	

	public Sprite Character (int n ) {

		if (n == 1)
			return character1;
		else if (n == 2)
			return character2;
		else
			return null;

	}

	public void CharacterSelect (int n, Sprite character) {

		if (n == 1)
			character1 = character;
		else if (n == 2)
			character2 = character;

	}



	public void PlayerNumbers (int P1, int P2) {

		player1 = P1;
		player2 = P2;

	}

	public int Numbers (int n) {

		if (n == 1)
			return player1;
		else
			return player2;

	}


}
