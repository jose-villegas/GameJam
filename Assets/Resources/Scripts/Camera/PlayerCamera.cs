using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour {
	// Camera's main references
	public Camera MainCamera;

	// Camera parameters
	public Vector3 CameraOffset = Vector3.zero;	// Centers the camera to the player
	[Range(0.01f,2.0f)]
	public float CameraMoveSpeed = 0.3f;
	[Range(0.01f,2.0f)]
	public float CameraScaleSpeed = 0.3f;

	// Target of the camera
	private PlayerStatus m_targetPlayer; 	// Only for singleplayer 
	private Vector3 m_targetPosition;

	// Control variables
	private Vector3 m_CCameraMoveVel = Vector3.zero;
	private float m_CCameraScaleVel = 0;

	// Use this for initialization
	public void Initialize() {
		// Get player reference
		m_targetPlayer = GameManager.Instance.Player;

		// Initialize target position
		UpdateTargetPosition();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTargetPosition();
		UpdateCameraPosition();
	}
	
	/// <summary>
	/// Updates the camera position.
	/// </summary>
	private void UpdateCameraPosition()
	{
		// Fix the camera height (this never changes)
		m_targetPosition.y = transform.position.y;
		// Update the position
		MainCamera.transform.position = Vector3.SmoothDamp(MainCamera.transform.position,m_targetPosition,ref m_CCameraMoveVel,CameraMoveSpeed);
	}

	/// <summary>
	/// Updates the target position: it will be the center between the players
	/// </summary>
	private void UpdateTargetPosition()
	{
		// Reset the position
		m_targetPosition = m_targetPlayer.transform.position;
		m_targetPosition += CameraOffset;
	}
	
}
