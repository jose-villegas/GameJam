using UnityEngine;
using System.Collections;

/// <summary>
/// Collision controller.
/// </summary>
public class CollisionController : MonoBehaviour {

	// Use this for initialization
	public void Initialize () {
	
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter(Collision collision) {
		Debug.Log (collision.collider.name);
	}
}
