using UnityEngine;
using System.Collections;

// random movement but charges against the player on detection
public class ChargingChiguire : MonoBehaviour {

    public float Speed = 2.0f;

    public float ChargingSpeed = 5.0f;

    public float MaxChangeDirectionFrequency = 2.0f;

    public float MaxStayStillChangeFrequency = 3.0f;
    public float MaxStayStillTime = 3.0f;

    public Vector3 RandomWalkingDirection;
    public bool StayStill = true;

    public float StartChargingDistance = 5.0f;
    public float DistanceToPlayer;
    public GameObject Player;

    private CharacterController _Character;

    private float _initialY;

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
            sumToTime += MaxStayStillTime * Random.Range(0.0f, 1.0f);
        }
        // Invoke again rand frequency
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f) + sumToTime);
    }

    // Use this for initialization
    void Start()
    {
        _Character = GetComponent<CharacterController>();
        _initialY = transform.position.y;
        Invoke("ChangeWalkingDirection", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
        Invoke("ChangeToStayStill", MaxStayStillChangeFrequency * Random.Range(0.0f, 1.0f));
    }

    private Vector3 _chargingDirection;
    private Vector3 _chargingFinalPosition;
    private float _chargingTimeSpend = 0.0f;
    private float _chargingTimeStop = 2.0f;
    private bool _chargingSet = true;
    private float _lastChargeTime = 0.0f;

    public float TimeBetweenCharges = 2.0f;

    private bool SetChargingDirection()
    {
        if (Time.fixedTime - _lastChargeTime < TimeBetweenCharges)
        {
            _chargingSet = false;
            return false;
        }

        // charging move once we are pass the target position (or we are beyond the charging time)
        float distanceToFinalPos = (transform.position - _chargingFinalPosition).sqrMagnitude;

        if (distanceToFinalPos <= 0.1 || _chargingTimeSpend > _chargingTimeStop  && _chargingSet)
        {
            _chargingSet = false;
            return false;
        }


        _chargingSet = true;
        _chargingDirection = (Player.transform.position - transform.position).normalized;
        _chargingFinalPosition = Player.transform.position;
        _chargingTimeSpend = 0.0f;
        _lastChargeTime = Time.fixedTime;

        return true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DistanceToPlayer = (Player.transform.position - transform.position).sqrMagnitude;

        if (DistanceToPlayer <= StartChargingDistance * StartChargingDistance && SetChargingDirection())
        {
            // move to player position on detection
            _Character.Move(this._chargingDirection * Time.deltaTime * ChargingSpeed);
            transform.position = new Vector3(transform.position.x, _initialY, transform.position.z);
            // sum to time spend charging mode
            _chargingTimeSpend += Time.deltaTime;
        } 
        else if (!this.StayStill && _Character != null && GameManager.Instance.GameState == GameManager.GameStatus.Playing)
        {
            _Character.Move(this.RandomWalkingDirection.normalized * Time.deltaTime * Speed);
            transform.position = new Vector3(transform.position.x, _initialY, transform.position.z);
        }
    }
}
