using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	// Player Controllers
	private MovementController m_Movement;

	// Gameplay Input listeners
	private bool m_Move;

	// Gameplay Keys
	public KeyCode MouseClick = KeyCode.Mouse0;

	// Keyboard & Mouse variables
	public LayerMask MouseLayer;			// Layer for mouse clics (Might be needed revisit this for the attack system)
	private PlayerCamera m_Camera;
	private Vector3 m_mouseWorldPos = Vector3.zero;
	private Vector3 m_mouseScreenPos = Vector3.zero;

	// Raycast variables (Keyboard & Mouse)
	private Ray _ray;
	private RaycastHit _hit;

	// Use this for initialization
	public void Initialize (MovementController movement) {
		// Set required player controllers
		m_Movement = movement;

		// Get player camera
		m_Camera = GameManager.Instance.PlayerCamera;
	}
	
	// Update is called once per frame
	void Update () {
		// Catch player input
		CatchGamePlayInput();

		// Execute movement input
		MovementInput();
	}


	// Gameplay Input
	void CatchGamePlayInput()
	{
		// Get mouse world position
		m_mouseWorldPos = GetMouseWorldPos();			// In networking mode, just pass the X and Z arguments of this vector

		// Catch input
		m_Move          = Input.GetKey(MouseClick);
	}


	/// <summary>
	/// Movement orders
	/// </summary>
	void MovementInput()
	{ 
		// Check if the movement key was pressed
		if (m_Move)
			// Try to move the character to the desired position
			m_Movement.TryMove(m_mouseWorldPos.x,m_mouseWorldPos.z);
	}


	////// UTILITIES //////
	/// <summary>
	/// Gets the mouse world position.
	/// </summary>
	/// <returns>The mouse world position.</returns>
	Vector3 GetMouseWorldPos()
	{
		// Get mouse position on the screen
		m_mouseScreenPos = Input.mousePosition; 
		
		// Send the new target position in world coordinates
		_ray = m_Camera.MainCamera.ScreenPointToRay(m_mouseScreenPos);
		Physics.Raycast(_ray,out _hit, Mathf.Infinity,MouseLayer);
		return _hit.point;
	}
}
