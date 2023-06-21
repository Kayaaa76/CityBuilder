using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingDatabase : MonoBehaviour
{
    public List<Building> buildingDatabase = new List<Building>();

    public static BuildingDatabase Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }
}
