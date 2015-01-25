﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	// Singleton
	static private UIManager _instance;
	static public UIManager Instance
	{
		get{return _instance;}
	}
	UIManager()
	{
		_instance = this;
	}
	// UI Reference
	public Text TimerLabel;
	public Button[] CivilianButtons = new Button[6];

	// Use this for initialization
	public void Initialize () {
		// First disable all buttons
		DisableAllCivilianButtons ();
	}

	/// <summary>
	/// Disables all civilian buttons.
	/// </summary>
	void DisableAllCivilianButtons()
	{
		foreach(Button currentbutton in CivilianButtons)
		{
			currentbutton.interactable = false;
		}
	}

	/// <summary>
	/// Adds the civilian.
	/// </summary>
	public void UpdateCivilians()
	{
		// Get secondary players currently holded
		SecondaryPlayer[] secondaryPlayer = GameManager.Instance.Player.GetSecondaryPlayers ();

		int index;
		foreach (Button currentbutton in CivilianButtons) {
		
			// Update index
			index++;
		}
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		// Update game timer
		TimerLabel.text = GameManager.Instance.CurrentTime;

		// Update civilian buttons
		UpdateCivilians ();
	}

}
