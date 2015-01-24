using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Attack controller.
/// </summary>
public class AttackController : MonoBehaviour {
	// List of holded player
	public List<SecondaryPlayer> holdedPlayers = new List<SecondaryPlayer>();

	// Use this for initialization
	public void Initialize () {
	
	}

	/// <summary>
	/// Holds the new secondary player.
	/// </summary>
	/// <param name="player">Player.</param>
	public void holdNewSecondaryPlayer(SecondaryPlayer player)
	{
		holdedPlayers.Add (player);
	}

	/// <summary>
	/// Throws the secondary player.
	/// </summary>
	/// <param name="targetWorldPosition">Target world position.</param>
	public void ThrowSecondaryPlayer(Vector3 targetWorldPosition)
	{
		
	}
}
