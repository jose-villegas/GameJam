using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SecondaryPlayer : MonoBehaviour {
	private Transform initialParent;
	private int Layer;

	private Sequence HelpSequence;

	// Use this for initialization
	void Start () {
		initialParent = transform.parent;
		Layer = gameObject.layer;

		// Create help animaton sequence
		HelpSequence = DOTween.Sequence ();
		float InitialLocalY = transform.localPosition.y;
		HelpSequence.Append (transform.DOLocalMoveY (1.0f, 0.5f));
		HelpSequence.Append (transform.DOLocalMoveY (InitialLocalY, 0.5f));
		HelpSequence.SetLoops (-1);

		StartHelpAnimationSequence ();
	}

	/// <summary>
	/// Starts the help animation sequence.
	/// </summary>
	void StartHelpAnimationSequence()
	{
		HelpSequence.Play ();
	}

	/// <summary>
	/// Resets the player.
	/// </summary>
	public void ResetParent()
	{
		transform.parent = initialParent;

	}

	public void ResetLayer()
	{
		gameObject.layer = Layer;
	}
}
