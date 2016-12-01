using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//scoreTextBox is the actual instance of the textbox itself
	Text scoreTextBox;
	//score is the actual score of the player (in integer form)
	int score;
	//what will be placed inside of scoreTextBox
	string text;
	//game over screen (for enabling/disabling)
	Canvas gameOverCanvas;

	// Use this for initialization
	void Start () {
		score = 0;
		text = "Score: " + score;
		scoreTextBox = this.GetComponent<Text> ();
		gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
		gameOverCanvas.enabled = false;
	}

	//call whenever an asteroid is destroyed (from object manager)
	public void asteroidDestroyed(){
		//score increases, text is reassigned and then scoreTextBox is updated
		score++;
		text = "Score: " + score;
		scoreTextBox.text = text;

		//if score is >= 42, then enable the game over screen
		if (score >= 42) {
			gameOverCanvas.enabled = true;
		} else {
			gameOverCanvas.enabled = false;
		}
	}
}
