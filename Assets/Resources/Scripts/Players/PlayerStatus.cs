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
    private void Start()
    {
        this._health = this.MaxHealth;
    }

    private InputController _input;

	// Use this for initialization
	public void Initialize() {
		// Get player controllers references
		_input = GetComponent<InputController> ();

		// Initialize player contollers
		_input.Initialize ();
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
