using UnityEngine;
using System.Collections;

/// <summary>
/// Collision controller.
/// </summary>
public class CollisionController : MonoBehaviour {
	// Game collision layers
	public LayerMask EnemyLayer;
	public LayerMask CivilianLayer;

	// Player references
	private PlayerStatus m_Status;
	private AttackController m_Attack;

	// Use this for initialization
	public void Initialize (PlayerStatus status,AttackController attack) {
		m_Status = status;
		m_Attack = attack;
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter(Collider other) {
		// Check if the collision is in the proper layer
		if (EnemyLayer == (EnemyLayer | (1 << other.gameObject.layer)))
			m_Status.ReduceHealth (1.0f);
		else if (CivilianLayer == (CivilianLayer | (1 << other.gameObject.layer)))
		{
			SecondaryPlayer civilian = other.GetComponent<SecondaryPlayer>();
			if(civilian != null)
				m_Attack.holdNewSecondaryPlayer(civilian);

		}
	}
}
