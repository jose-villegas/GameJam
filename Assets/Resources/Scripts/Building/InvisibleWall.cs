using UnityEngine;
using System.Collections;
using DG.Tweening;

public class InvisibleWall : MonoBehaviour {

	public LayerMask CitizensLayer;
	public LayerMask FlyingCitizensLayer;

	void OnTriggerEnter(Collider collider)
	{
		if (FlyingCitizensLayer == (FlyingCitizensLayer | (1 << collider.gameObject.layer)) ||
		    CitizensLayer == (CitizensLayer | (1 << collider.gameObject.layer)))
		{
				collider.gameObject.transform.DOPlayBackwards();
		}
	}
}
