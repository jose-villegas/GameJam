using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingBase : MonoBehaviour
{
    public enum BuildingType
    {
        NoBonus,
        Defense,
        TurboSpeed
    };

    // every building has a collection of current living residents
    protected List<SecondaryPlayer> Residents;
    // direct access to player status
    public PlayerStatus PlayerBonus;
    // buildings constrains
    public int MaxResidents = 5;

    public BuildingType BuildType;
    // Only for turbo speed buildings
    public float BonusSpeed = 1.0f;

    // Use this for initialization
	void Start () {
	    this.Residents = new List<SecondaryPlayer>();
	}

	// Update is called once per frame
	void Update () {
	
	}

    public bool IsBuildingFull()
    {
        return this.Residents.Count >= MaxResidents;
    }

    public void AddResident(SecondaryPlayer newResident)
    {
        if (this.Residents.Count >= this.MaxResidents) return;

        this.Residents.Add(newResident);

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
}
