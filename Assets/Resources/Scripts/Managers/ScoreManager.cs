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

    public void AddToScore(float value)
    {
        CurrentScore += value * this.ScoreMultiplier;
    }

    public void SaveHighScore()
    {
       // if (!(this.CurrentScore > this.HighScore)) return;

		string PlayerName = PlayerPrefs.GetString ("Player Name", "DEFAULT PLAYER");

        //PlayerPrefs.SetFloat("High Score", this.HighScore);
		PlayerPrefs.SetFloat("High Score", this.CurrentScore);
		PlayerPrefs.SetString("High Scorer", PlayerName);
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
