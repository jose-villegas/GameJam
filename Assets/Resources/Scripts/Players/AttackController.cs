using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Attack controller.
/// </summary>
public class AttackController : MonoBehaviour {
	// List of holded player
	public List<SecondaryPlayer> holdedPlayers = new List<SecondaryPlayer>();
	public Transform holdedPlayersParent;

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
		player.transform.localPosition = Vector3.zero;
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

	}
}
