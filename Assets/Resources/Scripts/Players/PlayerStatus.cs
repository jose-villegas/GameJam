using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    private float _health;

    public float MaxHealth = 1.0f;
    public float MinHealth = 0.0f;
    public float Speed = 1.0f;

    public List<StatusBehaviour> PlayerStatuses;

    // Use this for initialization
	void Start ()
	{
	    this._health = this.MaxHealth;
	}

	// Update is called once per frame
	void Update () {
	
	}

    void ReduceHealth(float value)
    {
        this._health = Mathf.Clamp(this._health - value, this.MinHealth, this.MaxHealth);
    }

    void RecoverHealth(float value)
    {
        this._health = Mathf.Clamp(this._health + value, this.MinHealth, this.MaxHealth);
    }
}
