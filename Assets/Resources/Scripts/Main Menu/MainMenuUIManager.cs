using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MainMenuUIManager : MonoBehaviour {
	// Camera movement
	[Range(0.1f,2.0f)]
	public float TransitionSpeed = 0.5f;

	// Sound FX
	public AudioSource PuntualAudio;
	public AudioClip SelectYourCharacter;
	public AudioClip Click;
	public AudioClip Woman;
	public AudioClip Man;

	// Use this for initialization
	void Start () {
	}

	IEnumerator DelayedAudio(AudioClip clip)
	{
		yield return new WaitForSeconds(TransitionSpeed/2.0f);
		PuntualAudio.PlayOneShot(clip,1.9f);
	}

	private void PlayClick()
	{
		PuntualAudio.PlayOneShot (Click, 1.0f);
	}

	/// <summary>
	/// Goes to game.
	/// </summary>
	/// <param name="choice">Choice.</param>
	public void GoToGame(int choice)
	{
		if(choice == 0)
			PuntualAudio.PlayOneShot(Woman,2.0f);
		else
			PuntualAudio.PlayOneShot(Man,2.0f);

	}

	/// <summary>
	/// GW	
	/// </summary>
	public void GoToPreGameMenu()
	{
		Camera.main.transform.DOLocalMoveY (-1200, TransitionSpeed);
		StartCoroutine ("DelayedAudio", SelectYourCharacter);
		PlayClick ();

	}

	public void GoToMainMenu()
	{
		Camera.main.transform.DOMove (new Vector3 (0, 0, Camera.main.transform.position.z), TransitionSpeed);
		PlayClick ();
	}

	public void GoToPlotMenu()
	{
		Camera.main.transform.DOLocalMoveX (1200, TransitionSpeed);
		PlayClick ();
	}

	public void GoToInstructionsMenu()
	{
		Camera.main.transform.DOLocalMoveX (-1200, TransitionSpeed);
		PlayClick ();

	}

	public void GoToCreditsMenu()
	{
		Camera.main.transform.DOLocalMoveY (1200, TransitionSpeed);
		PlayClick ();

	}
}
