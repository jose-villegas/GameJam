using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	// Use this for initialization
	public void Initialize () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Try to move the player towards the desired position
	/// </summary>
	public bool TryMove(float XPos,float ZPos)
	{ 
		/*
		// Check if the game is playing
		if(GameManager.Instance.GameState != GameManager.GameStatus.Playing)return false;
		
		// Check if the player can move
		if (!m_Status.canMove()) return false;
		
		// Construct the proper target vector
		m_TargetWorldPos = new Vector3(XPos, StageManager.Instance.StageFloorHeight , ZPos);
		
		// Get the required speed for this movement
		m_CurrentSpeed = MaxMovementSpeed * Mathf.Clamp(Vector3.Distance(transform.position, m_TargetWorldPos) / maxSpeedDistance,0,1);
		
		// Get the normalized player direction
		m_MoveDirection = GetTargetDirection(m_TargetWorldPos).normalized;
		
		// Check if the player can move to the desired position
		if(!m_Collision.canMoveTo(transform.position + m_MoveDirection * m_CharController.radius))return false;
		
		// Try to move the character to the desired position
		m_CharController.Move(m_MoveDirection * m_CurrentSpeed * Time.deltaTime);
		
		// Rotate Character towards movement
		Vector3 DestinationTarget = transform.position + m_MoveDirection;
		TryRotateTowards (DestinationTarget.x, DestinationTarget.z);
		
		// Update Control Flag
		m_RunningThisFrame = true;
		*/
		// End movement calculation
		return true;
	}
}
