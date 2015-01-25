using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MainMenuUIManager : MonoBehaviour {
	// Camera movement
	[Range(0.1f,2.0f)]
	public float TransitionSpeed = 0.5f;

	// Scene management
	public string MapOne = "Map 1";

	public Transform top;
	public Transform bot;
	public Transform left;
	public Transform right;

	public Ease easeness = Ease.OutBounce;

	// Sound FX
	public AudioSource PuntualAudio;
	public AudioClip SelectYourCharacter;
	public AudioClip Click;
	public AudioClip Woman;
	public AudioClip Man;
	public AudioSource Narration;

	// Use this for initialization
	void Start () {
	}

	IEnumerator DelayedAudio(AudioClip clip)
	{
		yield return new WaitForSeconds(TransitionSpeed/2.0f);
		PuntualAudio.PlayOneShot(clip,1.9f);
	}

	IEnumerator DelayedNarration()
	{
		yield return new WaitForSeconds(TransitionSpeed/2.0f);
		Narration.Stop ();
		Narration.Play ();
	}

	private void PlayClick()
	{
		Narration.Stop ();
		PuntualAudio.PlayOneShot (Click, 1.0f);
	}

	/// <summary>
	/// Goes to game.
	/// </summary>
	/// <param name="choice">Choice.</param>
	public void GoToGame(int choice)
	{
		PlayerPrefs.SetInt ("GENDER", choice);
		if(choice == 0)
		{
			PuntualAudio.PlayOneShot(Woman,2.0f);
			StartCoroutine ("DelayedGame",Woman);
		}
		else
		{
			PuntualAudio.PlayOneShot(Man,2.0f);
			StartCoroutine ("DelayedGame",Man);
		}


	}

	IEnumerator DelayedGame(AudioClip prefx)
	{
		yield return new WaitForSeconds (prefx.length);
		Application.LoadLevel (MapOne);
	}

	/// <summary>
	/// GW	
	/// </summary>
	public void GoToPreGameMenu()
	{
		Camera.main.transform.DOLocalMoveY (-(top.transform.position.y - bot.transform.position.y)/2.0f, TransitionSpeed).SetEase(easeness);
		StartCoroutine ("DelayedAudio", SelectYourCharacter);
		PlayClick ();

	}

	public void GoToMainMenu()
	{
		Camera.main.transform.DOMove (new Vector3 (0, 0, Camera.main.transform.position.z), TransitionSpeed).SetEase(easeness);
		PlayClick ();
	}

	public void GoToPlotMenu()
	{
		Camera.main.transform.DOLocalMoveX (-(left.transform.position.x - right.transform.position.x)/2.0f, TransitionSpeed).SetEase(easeness);
		PlayClick ();
		StartCoroutine ("DelayedNarration");

	}

	public void GoToInstructionsMenu()
	{
		Camera.main.transform.DOLocalMoveX ((left.transform.position.x - right.transform.position.x)/2.0f, TransitionSpeed).SetEase(easeness);
		PlayClick ();

	}

	public void GoToCreditsMenu()
	{
		Camera.main.transform.DOLocalMoveY ((top.transform.position.y - bot.transform.position.y)/2.0f, TransitionSpeed).SetEase(easeness);
		PlayClick ();

	}
}
