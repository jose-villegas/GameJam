using UnityEngine;
using System.Collections;

public class SecondaryPlayer : MonoBehaviour {
	private Transform initialParent;
	private int Layer;
	// Use this for initialization
	void Start () {
		initialParent = transform.parent;
		Layer = gameObject.layer;
	}

	/// <summary>
	/// Resets the player.
	/// </summary>
	public void ResetPlayer()
	{
		transform.parent = initialParent;

	}

	public void ResetLayer()
	{
		gameObject.layer = Layer;
	}
}
