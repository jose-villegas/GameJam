using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

/// <summary>
/// Game manager: Controls the main game flow
/// </summary>
public class GameManager : MonoBehaviour {
	// Singleton
	static private GameManager _instance;
	static public GameManager Instance
	{
		get{return _instance;}
	}
	// Player Sprite
	public Texture2D MALE;
	public Texture2D MALE2;
	public Texture2D FEMALE;
	public Texture2D FEMALE2;


	// Camera effect
	private TwirlEffect _twirl;
	public float TwirlTime = 2.0f;

	// Stages to load
	public string MainMenu = "Main Menu";
	public string ScoreScene = "Score Scene";
	public int maxScene = 5;
	// Buildings
	public BuildingBase[] buildings;
	public List<BuildingBase> requiredBuildingsToWin = new List<BuildingBase> ();

	// Game timer
	public string CurrentTime							// Current Match time (For UI)
	{
		get
		{
			return Mathf.FloorToInt((MaxStageTime - m_currentTime)/60.0f).ToString("00")
			+":" 
			+Mathf.FloorToInt((MaxStageTime - m_currentTime)%60.0f).ToString("00");
		}
	}
	private float m_currentTime = 0;				 	// Match Timer
	[Range(1,1000)]
	public float MaxStageTime	= 360.0f;				// Match max timer

	// Player Reference
	public PlayerStatus Player;
	public PlayerCamera PlayerCamera;

	// Game information
	public GameStatus GameState = GameStatus.Playing; // Current Game Status

	// Use this for initialization
	void Awake () {
		_instance = this;

		// Avoid this class destruction when in stage transition
		DontDestroyOnLoad (this.gameObject);

		// Begin game timer
		BeginStage ();
	}
 
	/// <summary>
	/// Raises the level was loaded event.
	/// </summary>
	/// <param name="level">Level.</param>
	void OnLevelWasLoaded(int level) {
		// Only execute the initialization if this isnt the first map
		if (level > 0 && Application.loadedLevelName != ScoreScene) {
			BeginStage();
		}
		else
			Destroy(this.gameObject);
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void LateUpdate()
	{
		if (GameState != GameStatus.Playing)
			return; 

		// Check win conditions
		int fullBuildingsCounter = 0;
		foreach(BuildingBase building in requiredBuildingsToWin)
		{
			if(building.IsBuildingFull())
				fullBuildingsCounter++;

			if(fullBuildingsCounter >= requiredBuildingsToWin.Count)
			{
				EndStage();
				return;
			}
		}
	}

	/// <summary>
	/// Begins the current stage.
	/// </summary>
	private void BeginStage()
	{
		// Initialize player
		Player = FindObjectOfType<PlayerStatus> ();
		Player.Initialize ();

		// Get player gender choice
		int Gender = PlayerPrefs.GetInt ("GENDER", 0);
		Texture2D PlayerSprite;
		Texture2D PlayerSprite1;
		if(Gender == 0)
		{
			PlayerSprite = FEMALE;
			PlayerSprite1= FEMALE2;
		}
		else
		{
			PlayerSprite = MALE;
			PlayerSprite1 = MALE2;
		}
		// Assign player texture
		AutoRotateMaterial SPRITEANIMATOR = Player.playerGameObject.GetComponent<AutoRotateMaterial> ();
		SPRITEANIMATOR.TEXTURES = new Texture2D[2];
		SPRITEANIMATOR.TEXTURES [0] = PlayerSprite;
		SPRITEANIMATOR.TEXTURES [1] = PlayerSprite1;

		// Initialize this stage buildings
		requiredBuildingsToWin.Clear ();
		buildings = FindObjectsOfType<BuildingBase> ();
		foreach(BuildingBase building in buildings)
		{
			building.Initialize(Player);
			if(building.BuildType == BuildingBase.BuildingType.NoBonus)
			{
				requiredBuildingsToWin.Add(building);
			}
		}

		// Initialize UI
		UIManager.Instance.Initialize ();
		
		// Initialize camera
		PlayerCamera.Initialize ();
		_twirl = PlayerCamera.GetComponent<TwirlEffect> ();

		// Begin stage timer
		StopCoroutine("MatchTimer");
		StartCoroutine("MatchTimer");

		// Set start flag
		GameState = GameStatus.Playing;
	}

	/// <summary>
	/// Ends the game.
	/// </summary>
	/// <param name="reason">Reason why the game must end.</param>
	public void EndStage()
	{
		// Stop Timer Coroutine
		StopCoroutine("MatchTimer");
		
		// Set the end game flag
		GameState = GameStatus.Ended;

		// Store score
		ScoreManager.Instance.AddToScore (MaxStageTime - m_currentTime);
		ScoreManager.Instance.SaveHighScore ();

		// Summon next stage if this isn't last
		int NextStage = Application.loadedLevel + 1;
		if (NextStage <= maxScene) {
			GameState = GameStatus.Paused;
			// Load next stage
			Application.LoadLevel(NextStage);
		}
		// If this is the last stage, end the game
		else
		{
			EndGame();
		}
	}

	public void Killed()
	{
		// Set safety conrol flag
		GameState = GameStatus.Ended;	
		DOTween.To(()=> _twirl.angle, x=> _twirl.angle = x, 113, TwirlTime);
		StartCoroutine ("DelayedKill");
	}

	IEnumerator DelayedKill()
	{
		yield return new WaitForSeconds (TwirlTime);
		// Destroy the cameras
		Destroy (this.gameObject);
		// Load score screen
		Application.LoadLevel(0);
	}

	// End of the game and go to the score screen
	public void EndGame()
	{
		// Set safety conrol flag
		GameState = GameStatus.Ended;
		// Destroy the cameras
		Destroy (this.gameObject);
		// Load score screen
		Application.LoadLevel(ScoreScene);
	}

	/// <summary>
	/// Match's Timer
	/// </summary>
	/// <returns>Match End.</returns>
	IEnumerator MatchTimer()
	{
		// Timer Initialization
		m_currentTime = 0;
		// Match timer
		while(m_currentTime < MaxStageTime)
		{
			// Check if the game is running
			if(GameState == GameStatus.Playing)
			{
				m_currentTime += Time.deltaTime;
			}
			yield return null;
		}
		
		// Match End due Time Runned Out
		EndStage();
	}

	// Game Status
	public enum GameStatus
	{
		Unstarted,
		Playing,
		Ended,
		Paused
	}
}
