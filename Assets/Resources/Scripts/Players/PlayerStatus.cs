using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    // defense status protects the user from the next enemy hit
    private bool _defenseStatusActive = false;
    // turbo speed status adds to the player add
    private float _turboSpeed = 0.0f;
    public float MaxTurboSpeed = 30.0f;

    private float _health;

    // Player health constrinas
    public float MaxHealth = 1.0f;
    public float MinHealth = 0.0f;

	// Player Controllers
	private InputController _inputController;
	private MovementController _movementController;
	private CollisionController _collisionController;

    // Use this for initialization
    private void Start()
    {
        this._health = this.MaxHealth;
    }



	// Use this for initialization
	public void Initialize() {
        // Get movement controller
        this._movementController = GetComponent<MovementController>();
		this._collisionController = GetComponent<CollisionController> ();
		this._inputController = GetComponent<InputController>();

		// Initialize player contollers
		this._movementController.Initialize(_collisionController);        
		this._inputController.Initialize(this._movementController);
		this._collisionController.Initialize ();
	}

    void AddToTurboSpeed(float value)
    {
        this._turboSpeed += Mathf.Min(value, MaxTurboSpeed);
    }

    float GetCurrentTurboSpeed()
    {
        return this._turboSpeed;
    }

	// Update is called once per frame
	void Update () {
	
	}

    void ReduceHealth(float value)
    {
        // defense status protects the player for the next incoming hit, then loses this status
        if (this._defenseStatusActive)
        {
            this._defenseStatusActive = false; return;
        }

        this._health = Mathf.Clamp(this._health - value, this.MinHealth, this.MaxHealth);
    }

    void RecoverHealth(float value)
    {
        this._health = Mathf.Clamp(this._health + value, this.MinHealth, this.MaxHealth);
    }
}
