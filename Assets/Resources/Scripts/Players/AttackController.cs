﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

/// <summary>
/// Attack controller.
/// </summary>
public class AttackController : MonoBehaviour {
	// List of holded player
	public List<SecondaryPlayer> holdedPlayers = new List<SecondaryPlayer>();
	public Transform holdedPlayersParent;

	// Throw Parameters
	[Range(1,20)]
	public float ThrowDistance = 5.0f;
	[Range(0.1f,5.0f)]
	public float ThrowTime = 1.0f;
	public int ThrowLayer;
	public Ease ThrowEase = Ease.Linear;

	// Use this for initialization
	public void Initialize () {
		if (!holdedPlayersParent)
			Debug.LogError ("Insert holded player parent transform");
	}

	/// <summary>
	/// Holds the new secondary player.
	/// </summary>
	/// <param name="player">Player.</param>
	public void holdNewSecondaryPlayer(SecondaryPlayer player)
	{
		// Add player to the list
		holdedPlayers.Add (player);

		// Save the gameobject to the player
		player.transform.parent = holdedPlayersParent;
		player.gameObject.SetActive (false);
	}

	/// <summary>
	/// Throws the secondary player.
	/// </summary>
	/// <param name="targetWorldPosition">Target world position.</param>
	public void ThrowSecondaryPlayer(Vector3 targetWorldPosition)
	{
		if (holdedPlayers.Count <= 0)
			return;

		// Remove last player
		SecondaryPlayer playerToThrow = holdedPlayers [holdedPlayers.Count - 1]; 
		holdedPlayers.RemoveAt(holdedPlayers.Count - 1);
		playerToThrow.ResetParent ();
		playerToThrow.gameObject.layer = ThrowLayer;

		// Set initial throw position
		Vector3 InitialPosition = playerToThrow.transform.position;
		InitialPosition.x = transform.position.x;
		InitialPosition.z = transform.position.z;
		playerToThrow.transform.position = InitialPosition;

		// Get throw direction
		targetWorldPosition.y = playerToThrow.transform.position.y;
		Vector3 throwDirection = targetWorldPosition - playerToThrow.transform.position;

		// Execute throw
		playerToThrow.gameObject.SetActive (true);
		playerToThrow.transform.DOMove (playerToThrow.transform.position + throwDirection.normalized * ThrowDistance,ThrowTime)
							   .SetEase(ThrowEase)
							   .OnComplete(()=>RestoreThrowedPlayer(playerToThrow));
							

	}

	/// <summary>
	/// Restores the throwed player.
	/// </summary>
	/// <param name="player">Player.</param>
	public void RestoreThrowedPlayer(SecondaryPlayer player)
	{
		player.ResetLayer ();
	}
}
