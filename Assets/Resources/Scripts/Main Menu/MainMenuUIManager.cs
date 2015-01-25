﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MainMenuUIManager : MonoBehaviour {
	// Camera movement
	[Range(0.1f,2.0f)]
	public float TransitionSpeed = 0.5f;

	// Sound FX
	public AudioSource PuntualAudio;
	public AudioClip SelectYourCharacter;

	// Use this for initialization
	void Start () {
	}

	IEnumerator DelayedAudio(AudioClip clip)
	{
		yield return new WaitForSeconds(TransitionSpeed/2.0f);
		PuntualAudio.PlayOneShot(clip,1.9f);
	}

	/// <summary>
	/// Goes to game.
	/// </summary>
	/// <param name="choice">Choice.</param>
	public void GoToGame(int choice)
	{

	}

	/// <summary>
	/// GW	
	/// </summary>
	public void GoToPreGameMenu()
	{
		Camera.main.transform.DOLocalMoveY (-1200, TransitionSpeed);
		StartCoroutine ("DelayedAudio", SelectYourCharacter);
	}

	public void GoToMainMenu()
	{
		Camera.main.transform.DOMove (new Vector3 (0, 0, Camera.main.transform.position.z), TransitionSpeed);
	}

	public void GoToPlotMenu()
	{
		Camera.main.transform.DOLocalMoveX (1200, TransitionSpeed);
	}

	public void GoToInstructionsMenu()
	{
		Camera.main.transform.DOLocalMoveX (-1200, TransitionSpeed);
	}

	public void GoToCreditsMenu()
	{
		Camera.main.transform.DOLocalMoveY (1200, TransitionSpeed);
	}
}
