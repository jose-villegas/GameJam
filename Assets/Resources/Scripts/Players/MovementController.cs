using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	// Movement variables
	[Range(0.10f,10.0f)]
	public float MaxMovementSpeed = 3.0f;
	private Vector3 m_MoveDirection = Vector3.zero;
	private Vector3 m_TargetWorldPos = Vector3.zero;
	private float m_CurrentSpeed = 0;
	[Range(1, 10)]
	public float maxSpeedDistance = 2.0f;

	// Character controller variables
	private CharacterController m_CharController;
	private CollisionController m_Collision;
	private PlayerStatus m_Status;

	// Use this for initialization
	public void Initialize (CollisionController collision,PlayerStatus status) {
		// Get Unity's character controller
		m_CharController = GetComponent<CharacterController>();
		m_Collision = collision;
		m_Status = status;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Try to move the player towards the desired position
	/// </summary>
	public bool TryMove(float XPos,float ZPos)
	{ 
		// Check if the game is playing
		if(GameManager.Instance.GameState != GameManager.GameStatus.Playing)return false;

		// Check if the player can move
		//if (!m_Status.canMove()) return false;
		
		// Construct the proper target vector
		m_TargetWorldPos = new Vector3(XPos,0, ZPos);
		
		// Get the required speed for this movement
		m_CurrentSpeed = (MaxMovementSpeed + m_Status.GetCurrentTurboSpeed())* m_Status.GetCurrentCivilianSlowdown() * Mathf.Clamp(Vector3.Distance(transform.position, m_TargetWorldPos) / maxSpeedDistance,0,1);

		// Get the normalized player direction
		m_MoveDirection = GetTargetDirection(m_TargetWorldPos).normalized;
		m_MoveDirection.y = 0;

		// Check if the player can move to the desired position
		//if(!m_Collision.canMoveTo(transform.position + m_MoveDirection * m_CharController.radius))return false;
		
		// Try to move the character to the desired position
		m_CharController.Move(m_MoveDirection * m_CurrentSpeed * Time.deltaTime);
		
		// Rotate Character towards movement
		Vector3 DestinationTarget = transform.position + m_MoveDirection;
		TryRotateTowards (DestinationTarget.x, DestinationTarget.z);

		// End movement calculation
		return true;
	}

	/// <summary>
	/// Tries the rotate towards.
	/// </summary>
	/// <returns><c>true</c>, if rotate towards was tryed, <c>false</c> otherwise.</returns>
	public bool TryRotateTowards(float XPos,float ZPos)
	{
		// Check if the player can rotate first
		//if(!m_Status.canRotate())return false;
		
		// Execute rotation
		transform.LookAt(new Vector3(XPos, 0 , ZPos));
		
		// Return success
		return true;
	}

	/// <summary>
	/// Gets the  target direction (using the player as origin point)
	/// </summary>
	/// <param name="TargetPos"></param>
	/// <returns></returns>
	public Vector3 GetTargetDirection(Vector3 TargetPos)
	{
		return TargetPos - transform.position;
	}
}
