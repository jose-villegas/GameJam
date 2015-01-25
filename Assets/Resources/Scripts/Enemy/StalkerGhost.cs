using UnityEngine;
using System.Collections;
// same as random movement enemy but it follows the player based on the distance
// better keep it slower than normal enemies
public class StalkerGhost : MonoBehaviour {

    public float Speed = 2.0f;

    public float MaxChangeDirectionFrequency = 2.0f;

    public float MaxStayStillChangeFrequency = 3.0f;
    public float MaxStayStillTime = 3.0f;

    public Vector3 RandomWalkingDirection;
    public bool StayStill = true;

    public float StartFollowingDistance = 5.0f;
    public float DistanceToPlayer;
    public GameObject Player;

    private float _initialY;

	// Use this for initialization
	void Start ()
	{
        // save initial height
	    _initialY = transform.position.y;
        // Start Randomizing movement
        Invoke("ChangeWalkingDirection", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
        DistanceToPlayer = (Player.transform.position - transform.position).sqrMagnitude;

	    if (DistanceToPlayer <= StartFollowingDistance * StartFollowingDistance)
	    {
            // non random direction, go directly for player
	        this.RandomWalkingDirection = Player.transform.position - transform.position;
            // move object
            this.transform.position += this.RandomWalkingDirection.normalized * Time.deltaTime * Speed;
            this.transform.position = new Vector3(transform.position.x, _initialY, transform.position.z);

	    } 
        else if (!this.StayStill && GameManager.Instance.GameState == GameManager.GameStatus.Playing)
        {
            this.transform.position += this.RandomWalkingDirection.normalized * Time.deltaTime * Speed;
            this.transform.position = new Vector3(transform.position.x, _initialY, transform.position.z);
        }
	}

    private void ChangeWalkingDirection()
    {
        // Assign a new random direction
        RandomWalkingDirection = Random.insideUnitSphere * Speed;

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
            sumToTime += MaxStayStillTime * Random.Range(0.0f, 1.0f);
        }
        // Invoke again rand frequency
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f) + sumToTime);
    }
}
