using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building 
{
    //Building ID for ref exact type of building.
    public int buildingID;

    //Building Level
    public int buildinglevel = 1;

    //width X axis
    public int width = 0;

    //length Z axis
    public int length = 0;

    public int yPadding = 0;

    //Visual of the building
    public GameObject buildingModel;

    //Type of Building
    public BuildingType buildingType = BuildingType.None;

    //Type of functionality of building
    public ResourceType resourceType = ResourceType.None;

    ////Type of storage of building
    //public StorageType storageType = StorageType.None;

    //[HideInInspector]
    public BuildingObject refOfBuilding;

    public enum ResourceType
    {
        None,
        Standard,
        Premium,
        Wood,
        Stone,
        Metal,
        Energy,
    }

    //public enum StorageType
    //{
    //    None,
    //    Wood,
    //    Stone,
    //    Metal,
    //    Energy
    //}

    public enum BuildingType
    {
        None,
        TownHall,
        Resource,
        Storage,
        WeaponmArmoury,
        RecruitmentCentre,
        ResearchLab
    }
}
