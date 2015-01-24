using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	// Player Controllers
	private InputController m_Input;
	private MovementController m_Movement;

	// Use this for initialization
	public void Initialize () {
		// Get player controllers references
		m_Input = GetComponent<InputController> ();
		m_Movement = GetComponent<MovementController> ();

		// Initialize player contollers
		m_Input.Initialize (m_Movement);
		m_Movement.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
