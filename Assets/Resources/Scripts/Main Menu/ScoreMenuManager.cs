using UnityEngine;
using System.Collections;

public class ScoreMenuManager : MonoBehaviour {
	// Scene transitions
	public string MainMenu = "Main Menu";
	// Use this for initialization
	void Start () {
		if(ScoreManager.Instance == null)
			return;
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
