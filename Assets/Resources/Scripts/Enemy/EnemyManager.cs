using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {
	// Singleton
	static private EnemyManager _instance;

    // stores all enemies movement script for batch modification
    public List<EnemyMovement> EnemiesMovement; 

	static public EnemyManager Instance
	{
		get{return _instance;}
	}

    EnemyManager()
	{
		_instance = this;
	}

    public void MultiplyEnemiesSpeed(float value)
    {
        foreach (EnemyMovement enemy in EnemiesMovement)
        {
            enemy.Speed *= value;
        }
    }

    public void AddEnemiesSpeed(float value)
    {
        foreach (EnemyMovement enemy in EnemiesMovement)
        {
            enemy.Speed += value;
        }
    }

	// Use this for initialization
	void Start ()
	{
        // do nothing
	}
	
	// Update is called once per frame
	void Update () 
    {
        // do nothing
	}
}
