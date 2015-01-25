using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour
{
    // sphere cast layer
    public LayerMask PlayerMask;

    private RaycastHit _sphereRay;
    // Use this for initialization
    private void Start()
    {
        // sphere ray cast layer
        this.PlayerMask = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider collider)
    {
        if(PlayerMask == (PlayerMask | (1 << collider.gameObject.layer)))
        {
            Debug.Log(collider.gameObject);
        }
    }
}
