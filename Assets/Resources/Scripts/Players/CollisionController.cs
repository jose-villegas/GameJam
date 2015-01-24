using UnityEngine;
using System.Collections;

/// <summary>
/// Collision controller.
/// </summary>
public class CollisionController : MonoBehaviour {
	// Enemy collision layer
	public LayerMask EnemyLayer;

	// Player references
	private PlayerStatus m_Status;

	// Use this for initialization
	public void Initialize (PlayerStatus status) {
		m_Status = status;
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter(Collider other) {
		// Check if the collision is in the proper layer
		if (EnemyLayer == (EnemyLayer | (1 << other.gameObject.layer)))
			m_Status.ReduceHealth (1.0f);
	}
}
