using UnityEngine;
using System.Collections;
using TreeEditor;

public class EnemyMovement : MonoBehaviour
{

    public float Speed = 2.0f;

    public float MaxChangeDirectionFrequency = 3.0f;

    public float MaxStayStillChangeFrequency = 5.0f;
    public float MaxStayStillTime = 5.0f;
    
    public Vector3 _randomWalkingDirection;
    public bool _stayStill = true;

    private void ChangeWalkingDirection()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = 0.0f; // No height change
        float z = Random.Range(-1.0f, 1.0f);
        // Assign a new random direction
        _randomWalkingDirection = new Vector3(x, y ,z);
        // Invoke again rand frequency
        Invoke("ChangeWalkingDirection", MaxChangeDirectionFrequency * Random.Range(0.0f, 1.0f));

    }

    private void ChangeToStayStill()
    {
        this._stayStill = !this._stayStill;
        // add to next invokation time if staying still
        float sumToTime = 0.0f;

        if (this._stayStill)
        {
            sumToTime += MaxStayStillTime*Random.Range(0.0f, 1.0f);
        }
        // Invoke again rand frequency
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f) + sumToTime);
    }

	// Use this for initialization
	void Start () {
        Invoke("ChangeWalkingDirection", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
	    if (!this._stayStill)
	    {
	        this.transform.Translate(this._randomWalkingDirection * Time.deltaTime);
	    }   
	}
}
