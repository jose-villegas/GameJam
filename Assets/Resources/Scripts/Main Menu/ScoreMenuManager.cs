using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMenuManager : MonoBehaviour {
	// Scene transitions
	public string MainMenu = "Main Menu";

	// Label references
	public Text playerScore;

	// Use this for initialization
	void Start () {

		playerScore.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("High Score", 0.0f)).ToString();
		//this._highScorer = PlayerPrefs.GetString("High Scorer", "Player");
	}
	
	/// <summary>
	/// Goes to game.
	/// </summary>
	/// <param name="choice">Choice.</param>
	public void GoToMainMenu()
	{
		Application.LoadLevel (MainMenu);	
	}
}
