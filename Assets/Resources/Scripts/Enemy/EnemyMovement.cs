using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float Speed = 2.0f;

    public float MaxChangeDirectionFrequency = 2.0f;

    public float MaxStayStillChangeFrequency = 3.0f;
    public float MaxStayStillTime = 3.0f;
    
    public Vector3 RandomWalkingDirection;
    public bool StayStill = true;
    public bool DisableRandomMovement = false;

	private CharacterController _Character;

	public AudioClip detectsound;
	public float RandomIntervalMIN = 10.0f;
	public float RandomIntervalMAX = 20.0f;
	IEnumerator RandomSound()
	{
		while (GameManager.Instance.GameState == GameManager.GameStatus.Playing) {
			yield return new WaitForSeconds(Random.Range(RandomIntervalMIN,RandomIntervalMAX));
			audio.PlayOneShot(detectsound);
		}
	}

	private float InitialY;

    private void ChangeWalkingDirection()
    {
        // Assign a new random direction
        RandomWalkingDirection = Random.insideUnitSphere * Speed;
		RandomWalkingDirection.y = 0;

        // Invoke again rand frequency
        Invoke("ChangeWalkingDirection", MaxChangeDirectionFrequency * Random.Range(0.0f, 1.0f));

    }

    private void ChangeToStayStill()
    {
        this.StayStill = !this.StayStill;
        // add to next invokation time if staying still
        float sumToTime = 0.0f;

        if (this.StayStill)
        {
            sumToTime += MaxStayStillTime*Random.Range(0.0f, 1.0f);
        }
        // Invoke again rand frequency
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f) + sumToTime);
    }

	// Use this for initialization
	void Start () {
		StartCoroutine ("RandomSound");

		_Character = GetComponent<CharacterController> ();
		InitialY = transform.position.y;
        Invoke("ChangeWalkingDirection", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!DisableRandomMovement && !this.StayStill && _Character != null && GameManager.Instance.GameState == GameManager.GameStatus.Playing)
	    {
			_Character.Move(this.RandomWalkingDirection.normalized * Time.deltaTime * Speed);
			transform.position = new Vector3(transform.position.x,InitialY,transform.position.z);
	    }   
	}
}
