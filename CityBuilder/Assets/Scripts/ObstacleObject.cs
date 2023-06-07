using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int resourceAmount = 10;
    TileObject refTile;

    /// <summary>
    /// This method is called whenever item is tapped/clicked
    /// works on Mobile/PC
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log(obstacleType);

        //onClick Event
        bool usedResource = false;

        //Can call directly the method tht adds resource
        switch (obstacleType) 
        {
            case ObstacleType.Wood:
                usedResource = ResourceManager.Instance.AddWood(resourceAmount);
                break;

            case ObstacleType.Stone:
                usedResource = ResourceManager.Instance.AddStone(resourceAmount);
                break;

            default: 
                break;
        }

        if (usedResource)
        {
            refTile.data.CleanTile();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }

    public void SetTileReference(TileObject obj)
    {
        refTile = obj;
    }

    
    public enum ObstacleType
    {
        Wood,
        Stone
    }
}
