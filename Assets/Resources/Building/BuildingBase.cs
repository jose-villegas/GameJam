using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingBase : MonoBehaviour
{
    // every building has a collection of current living residents
    private List<SecondaryPlayer> _residents;
    // buildings constrains
    public int MaxResidents = 5;

    // Use this for initialization
	void Start () {
	    this._residents = new List<SecondaryPlayer>();
	}

	// Update is called once per frame
	void Update () {
	
	}

    void AddResident(SecondaryPlayer newResident)
    {
        if (this._residents.Count >= this.MaxResidents) return;

        this._residents.Add(newResident);
    }

    void ClearBuilding()
    {
        this._residents.Clear();
    }
}
