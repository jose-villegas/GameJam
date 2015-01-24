using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	// Singleton
	static private ScoreManager _instance;

    public float CurrentScore = 0.0f;
    public float ScoreMultiplier = 1.0f;
    public float HighScore;

    private string _highScorer;

	static public ScoreManager Instance
	{
		get{return _instance;}
	}

    string GetHighestScoreName()
    {
        return this._highScorer;
    }

    void AddToScore(float value)
    {
        CurrentScore += value * this.ScoreMultiplier;
    }

    void SaveHighScore(string scorer)
    {
        if (!(this.CurrentScore > this.HighScore)) return;

        PlayerPrefs.SetFloat("High Score", this.HighScore);
        PlayerPrefs.SetString("High Scorer", scorer);
    }

	ScoreManager()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start ()
	{
	    this.HighScore = PlayerPrefs.GetFloat("High Score", 0.0f);
	    this._highScorer = PlayerPrefs.GetString("High Scorer", "Player");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
