using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	// Singleton
	static private ScoreManager _instance;
	static public ScoreManager Instance
	{
		get{return _instance;}
	}
	ScoreManager()
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
