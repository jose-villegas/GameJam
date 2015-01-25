using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
	// Player Controllers
	private InputController _inputController;
	private MovementController _movementController;
	private CollisionController _collisionController;
	private AttackController _attackController;

    // defense status protects the user from the next enemy hit
    private bool _defenseStatusActive = false;
    // turbo speed status adds to the player add
    private float _turboSpeed = 0.0f;
    public float MaxTurboSpeed = 30.0f;

    private float _health;

    // Player health constrinas
    public float MaxHealth = 1.0f;
    public float MinHealth = 0.0f;

    // Use this for initialization
    private void Start()
    {
        this._health = this.MaxHealth;
    }

    public void ActivateDefenseStatus()
    {
        this._defenseStatusActive = true;
    }

    public bool IsDefenseStatusActive()
    {
        return this._defenseStatusActive;
    }

	// Use this for initialization
	public void Initialize() {
        // Get movement controller
        this._movementController = GetComponent<MovementController>();
		this._collisionController = GetComponent<CollisionController> ();
		this._inputController = GetComponent<InputController>();
		this._attackController = GetComponent<AttackController> ();

		// Initialize player contollers
		this._movementController.Initialize(_collisionController,this);        
		this._inputController.Initialize(this._movementController,this._attackController);
		this._collisionController.Initialize (this,_attackController);
		this._attackController.Initialize ();
	}


    public void AddToTurboSpeed(float value)
    {
        this._turboSpeed += Mathf.Min(value, MaxTurboSpeed);
    }

	public SecondaryPlayer[] GetSecondaryPlayers()
	{
		return _attackController.holdedPlayers.ToArray ();
	}

    public float GetCurrentTurboSpeed()
    {
        return this._turboSpeed;
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void ReduceHealth(float value)
    {
		if (GameManager.Instance.GameState != GameManager.GameStatus.Playing)
					return;
        // defense status protects the player for the next incoming hit, then loses this status
        if (this._defenseStatusActive)
        {
            this._defenseStatusActive = false; return;
        }

        this._health = Mathf.Clamp(this._health - value, this.MinHealth, this.MaxHealth);

		// Check if the player is killed
		if (_health <= 0f)
			GameManager.Instance.Killed();
    }

    public void RecoverHealth(float value)
    {
        this._health = Mathf.Clamp(this._health + value, this.MinHealth, this.MaxHealth);
    }
}
