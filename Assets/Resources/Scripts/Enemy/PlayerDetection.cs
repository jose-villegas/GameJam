﻿using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour
{
    // sphere cast layer
    public LayerMask PlayerMask;
    private GameObject _player;

    // random movement script to disable on following mode
    public EnemyMovement EnemyMovementScript;

    // movement speed
    public float Speed = 2.5f;

    // persecution time, tells for how much time the enemy will follow the player direction
    public float MaxPersecutionTime = 2.0f;
    private bool _startPersecution = false;
    private float _timeFollowing = 0.0f;
    private float _followingTimeToSpend = 0.0f;
    private Vector3 _directionToPlayer;

    private RaycastHit _sphereRay;

	private float InitialY;
    // Use this for initialization
    private void Start()
    {
        // sphere ray cast layer
        this.PlayerMask = LayerMask.GetMask("Player");
        _directionToPlayer = new Vector3(0.0f, 0.0f, 0.0f);
		InitialY = transform.position.y;

    }

    // Update is called once per frame
	void Update () {
	    if (_startPersecution && _timeFollowing <= _followingTimeToSpend)
	    {
	        _timeFollowing += Time.deltaTime;

            // move to player
	        this.transform.position += _directionToPlayer * Speed * Time.deltaTime;
	        this.transform.position.Set(transform.position.x, InitialY, transform.position.y);
            // reset values on end of following time
	        if (_timeFollowing >= _followingTimeToSpend)
	        {
	            _startPersecution = false;
	        }
	    }

	    this.EnemyMovementScript.DisableRandomMovement = _startPersecution;
	}

    void OnTriggerEnter(Collider collider)
    {
        if(PlayerMask == (PlayerMask | (1 << collider.gameObject.layer)) && !_startPersecution)
        {
            this._player = collider.gameObject;
            // start following player on detection
            _startPersecution = true;
            // set up variables for following loop
            this._timeFollowing = 0.0f;
            this._followingTimeToSpend = this.MaxPersecutionTime*Random.Range(0.0f, 1.0f);
            // get direction to player
            _directionToPlayer = _player.transform.position - this.transform.position;
			_directionToPlayer.y = InitialY;
            _directionToPlayer = _directionToPlayer.normalized;

        }
    }
}
