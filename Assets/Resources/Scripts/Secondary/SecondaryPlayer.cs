using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class SecondaryPlayer : MonoBehaviour {
	private Transform initialParent;
	private int Layer;

	private Sequence HelpSequence;

	// Audio FX
	public float MinRandomTime = 10.0f;
	public float MaxRandomTime = 20.0f;
	public AudioClip WhatDoWeDoKnow;
	public Sprite CivilianSprite;

	private Quaternion pastQuaternion;

	// Use this for initialization
	void Start () {
		initialParent = transform.parent;
		Layer = gameObject.layer;
		pastQuaternion = transform.rotation;
		// Create help animaton sequence
		HelpSequence = DOTween.Sequence ();
		float InitialLocalY = transform.localPosition.y;
		HelpSequence.Append (transform.DOLocalMoveY (1.0f, 0.5f));
		HelpSequence.Append (transform.DOLocalMoveY (InitialLocalY, 0.5f));
		HelpSequence.SetLoops (-1);

		StartHelpAnimationSequence ();

		if(WhatDoWeDoKnow != null)
			StartCoroutine ("WhatDoWeDoNow");
	}

	void LateUpdate()
	{
		transform.rotation = pastQuaternion;
	}

	/// <summary>
	/// Whats the do we do now.
	/// </summary>
	/// <returns>The do we do now.</returns>
	IEnumerator WhatDoWeDoNow (){
		while(GameManager.Instance.GameState != GameManager.GameStatus.Ended)
		{
			yield return new WaitForSeconds (Random.Range(MinRandomTime,MaxRandomTime ));	
			audio.PlayOneShot(WhatDoWeDoKnow);
		}
	}

	/// <summary>
	/// Starts the help animation sequence.
	/// </summary>
	void StartHelpAnimationSequence()
	{
		HelpSequence.Play ();
	}

	public void Hide(Transform newParent)
	{
		// Save the gameobject to the player
		transform.parent = newParent;
		gameObject.SetActive (false);
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
