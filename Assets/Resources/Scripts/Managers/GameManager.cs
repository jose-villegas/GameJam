using UnityEngine;
using System.Collections;


/// <summary>
/// Game manager: Controls the main game flow
/// </summary>
public class GameManager : MonoBehaviour {
	// Singleton
	static private GameManager _instance;
	static public GameManager Instance
	{
		get{return _instance;}
	}
	GameManager()
	{
		_instance = this;
	}

	// Player Reference
	public PlayerStatus Player;
	public PlayerCamera PlayerCamera;

	// Use this for initialization
	void Start () {

		// Initialize player
		Player.Initialize ();

		// Initialize camera
		PlayerCamera.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
