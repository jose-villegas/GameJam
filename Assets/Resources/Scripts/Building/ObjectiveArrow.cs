using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ObjectiveArrow : MonoBehaviour {
	private Sequence HelpSequence;

	// Use this for initialization
	void Start () {
		// Create help animaton sequence
		HelpSequence = DOTween.Sequence ();
		float InitialLocalY = transform.localPosition.y;
		HelpSequence.Append (transform.DOLocalMoveY (InitialLocalY + 0.5f, 0.5f));
		HelpSequence.Append (transform.DOLocalMoveY (InitialLocalY, 0.5f));
		HelpSequence.SetLoops (-1);
		HelpSequence.Play ();

		transform.DORotate (new Vector3(0,360.0f,0), 1.0f, RotateMode.LocalAxisAdd).SetLoops (-1);
	}
}
