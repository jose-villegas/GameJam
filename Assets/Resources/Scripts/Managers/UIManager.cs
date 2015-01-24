using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	// UI Reference
	public Text TimerLabel;

	// Use this for initialization
	public void Initialize () {
	
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		// Update game timer
		TimerLabel.text = GameManager.Instance.CurrentTime;
	}

}
