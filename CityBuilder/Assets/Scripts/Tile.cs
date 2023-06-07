using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile 
{
    //Building ref tht each tile will hv for each building
    public BuildingObject buildingRef;

    public ObstacleType obstacleType;

    bool isStarterTile = true;

    #region Methods
    //The stuff tht the tile is being occupied by.
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void SetOccupied(ObstacleType t)
    {
        obstacleType = t;
    }

    public void SetOccupied(ObstacleType t, BuildingObject b)
    {
        obstacleType = t;

        buildingRef = b;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
    }

    public void StarterTileValue(bool value)
    {
        isStarterTile = value;
    }

    #endregion

    #region Booleans
    public bool IsOccupied
    {
        get
        {
            return obstacleType != ObstacleType.None;
        }
    }

    public bool CanSpawnObstacle
    {
        get
        {
            return !isStarterTile;
        }
    }

    #endregion
}
