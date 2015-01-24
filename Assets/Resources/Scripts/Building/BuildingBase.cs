using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class BuildingBase : MonoBehaviour
{
    public enum BuildingType
    {
        NoBonus,
        Defense,
        TurboSpeed
    };

    public LayerMask CitizensLayer;
    public LayerMask FlyingCitizensLayer;

    void Start()
    {
        CitizensLayer = LayerMask.GetMask("Civilians");
        FlyingCitizensLayer = LayerMask.GetMask("Throwed Player");
    }

    // every building has a collection of current living residents
	public List<SecondaryPlayer> Residents;
    // direct access to player status
    public PlayerStatus PlayerBonus;
    // buildings constrains
    public int MaxResidents = 5;

    public BuildingType BuildType;
    // Only for turbo speed buildings
    public float BonusSpeed = 1.0f;


    // Use this for initialization
	public void Initialize (PlayerStatus status) {
		this.PlayerBonus = status;
	    this.Residents = new List<SecondaryPlayer>();
	}


    public bool IsBuildingFull()
    {
        return this.Residents.Count >= MaxResidents;
    }

    public void AddResident(SecondaryPlayer newResident)
    {
        if (this.Residents.Count >= this.MaxResidents) return;

        this.Residents.Add(newResident);

		// Hide this resident
		newResident.Hide (this.transform);

        // Depending on build type we assign the player status a current bonus
        if (BuildType == BuildingType.Defense)
        {
            this.PlayerBonus.ActivateDefenseStatus();
        }
        else if (BuildType == BuildingType.TurboSpeed)
        {
            this.PlayerBonus.AddToTurboSpeed(this.BonusSpeed);
        }
    }

    public void ClearBuilding()
    {
        this.Residents.Clear();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        if (FlyingCitizensLayer == (FlyingCitizensLayer | (1 << collider.gameObject.layer)) ||
            CitizensLayer == (CitizensLayer | (1 << collider.gameObject.layer)))
        {
            if (!this.IsBuildingFull())
            {
                this.AddResident(collider.gameObject.GetComponent<SecondaryPlayer>());
            }
			else
			{
				collider.gameObject.transform.DOPlayBackwards();
			}

        }
    }
}
