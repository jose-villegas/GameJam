using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    private float _health;

    // Player health constrinas
    public float MaxHealth = 1.0f;
    public float MinHealth = 0.0f;

    public float Speed = 1.0f;

    // Use this for initialization
    private void Start()
    {
        this._health = this.MaxHealth;
    }

	private InputController _inputController;
	private MovementController _movementController;

	// Use this for initialization
	public void Initialize() {
        // Get movement controller
        this._movementController = GetComponent<MovementController>();

		// Initialize player contollers
        this._movementController.Initialize();

        // Get player controllers references
        this._inputController = GetComponent<InputController>();

        // Initialize player contollers
        this._inputController.Initialize(this._movementController);
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
