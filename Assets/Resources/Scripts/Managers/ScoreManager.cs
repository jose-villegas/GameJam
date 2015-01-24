using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	// Singleton
	static private ScoreManager _instance;

    public float CurrentScore = 0.0f;
    public float ScoreMultiplier = 1.0f;
    public float HighScore;

	static public ScoreManager Instance
	{
		get{return _instance;}
	}

    void AddToScore(float value)
    {
        CurrentScore += value * this.ScoreMultiplier;
    }

    void SaveHighScore()
    {
        if (this.CurrentScore > this.HighScore)
        {
            PlayerPrefs.SetFloat("High Score", this.HighScore);
        }
    }

	ScoreManager()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start ()
	{
	    this.HighScore = PlayerPrefs.GetFloat("High Score");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
