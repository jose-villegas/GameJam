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

	private CharacterController _Character;

    private void ChangeWalkingDirection()
    {
        // Assign a new random direction
        _randomWalkingDirection = Random.insideUnitSphere * Speed;
		_randomWalkingDirection.y = 0;

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
		_Character = GetComponent<CharacterController> ();

        Invoke("ChangeWalkingDirection", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!this._stayStill && _Character != null)
	    {
			_Character.Move(this._randomWalkingDirection.normalized * Time.deltaTime * Speed);
	    }   
	}
}
