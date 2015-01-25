using UnityEngine;
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
	public Image[] CivilianImages = new Image[6];

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
		int index = 0;
		foreach(Button currentbutton in CivilianButtons)
		{
			currentbutton.interactable = false;
			CivilianImages[index] = currentbutton.GetComponent<Image>();
			CivilianImages[index].color = new Color(1,1,1,0);
			index++;
		}
	}

	/// <summary>
	/// Adds the civilian.
	/// </summary>
	public void UpdateCivilians()
	{

		if (GameManager.Instance.Player == null)
						return;

		// Get secondary players currently holded
		SecondaryPlayer[] secondaryPlayers = GameManager.Instance.Player.GetSecondaryPlayers ();

		int index = 0;
		foreach (Button currentbutton in CivilianButtons) {
			// Refresh buttons
			if(secondaryPlayers.Length > index)
			{
				currentbutton.interactable = true;
				CivilianImages[index].sprite = secondaryPlayers[index].CivilianSprite;
				CivilianImages[index].color = new Color(1,1,1,1);
			}
			else
			{
				currentbutton.interactable = false;
				CivilianImages[index].color = new Color(1,1,1,0);
			}
			// Update index
			index++;
		}
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		if(GameManager.Instance.GameState != GameManager.GameStatus.Playing)return;


		// Update game timer
		TimerLabel.text = GameManager.Instance.CurrentTime;

		// Update civilian buttons
		UpdateCivilians ();
	}

}
