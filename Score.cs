using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	public GameObject WinCanvas;
	public Text score1, score2, WinScore, Winner;
	public Image player1, player2, winnerPlayer;

	public Animator P1, P2, WinScene;

	public int scoreP1, scoreP2, maxScore;
	public int player1number, player2number, winnerNumber;

	void Awake () {
	
		scoreP1 = 0;
		scoreP2 = 0;
		maxScore = 11;

		score1.text = scoreP1.ToString ();
		score2.text = scoreP2.ToString ();
		WinScore.text = maxScore.ToString ();

		player1.sprite = FindObjectOfType<Selection> ().Character (1);
		player2.sprite = FindObjectOfType<Selection> ().Character (2);

		player1number = FindObjectOfType<Selection> ().Numbers (1);
		player2number = FindObjectOfType<Selection> ().Numbers (2);

	}
	

	public void SetScore (int player) {

		if (player == 1) {

			scoreP1++;
			score1.text = scoreP1.ToString ();
			PlayAudio (1);
			P1.SetBool ("Point", true);

		} else {
		
			scoreP2++;
			score2.text = scoreP2.ToString ();
			PlayAudio (2);
			P2.SetBool ("Point", true);

		}

		Invoke ("StopAnim", 1.333f);

		if (scoreP1 == scoreP2 && scoreP1 == (maxScore - 1)) {

			maxScore++;
			WinScore.text = maxScore.ToString ();
			FindObjectOfType<EgoBall> ().MaxTurno (1);

		}


		if (scoreP1 == maxScore)
			Win (1);
		else if (scoreP2 == maxScore)
			Win (2);

	}

	public void Win (int player) {
		
		WinCanvas.SetActive (true);

		Invoke ("WinIdle", 2.75f); 

		if (player == 1) {

			winnerNumber = player1number;
			winnerPlayer.sprite = player1.sprite;
			Winner.text = player1.sprite.name + " Win";

		} else if (player == 2) {

			winnerNumber = player2number;
			winnerPlayer.sprite = player2.sprite;
			Winner.text = player2.sprite.name + " Win";

		}


	}



	public void BackToMenu () {

		FindObjectOfType<AudioManager> ().EgoTheme (1f);
		SceneManager.LoadScene (0);

	}


	public void PlayAudio (int n) {

		if (n == 1)
			FindObjectOfType<AudioManager> ().PlayAudio ("Character" + player1number.ToString ());
		else if (n == 2)
			FindObjectOfType<AudioManager> ().PlayAudio ("Character" + player2number.ToString ());
		else if (n == 3)
			FindObjectOfType<AudioManager> ().PlayAudio ("Character" + winnerNumber.ToString ());

	}

	void StopAnim () {

		P1.SetBool ("Point", false);
		P2.SetBool ("Point", false);

	}

	void WinIdle () {

		WinScene.SetBool ("WinIdle", true);

	}

}
