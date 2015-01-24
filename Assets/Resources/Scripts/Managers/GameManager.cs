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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
