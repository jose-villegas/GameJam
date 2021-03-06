﻿using UnityEngine;
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
	public PlayerStatus m_targetPlayer; 	// Only for singleplayer 
	private Vector3 m_targetPosition;

	// Control variables
	private Vector3 m_CCameraMoveVel = Vector3.zero;
	private float m_CCameraScaleVel = 0;

	// Use this for initialization
	public void Initialize() {

	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.GameState != GameManager.GameStatus.Playing)return;
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
		if(GameManager.Instance.Player == null)
		{
			Debug.Log("CONIOOOOO");
			return;
		}
		// Reset the position
		m_targetPosition = GameManager.Instance.Player.transform.position;
		m_targetPosition += CameraOffset;
	}
	
}
