using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	// Player Controllers
	private InputController m_Input;

	// Use this for initialization
	public void Initialize () {
		// Get player controllers references
		m_Input = GetComponent<InputController> ();

		// Initialize player contollers
		m_Input.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
