using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public Tile data;

    [Header("World Tile Data")]
    [Space(8)]

    //Position of the tile
    public int xPos = 0;
    public int zPos = 0;

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);

        if (!data.IsOccupied)
        {
            if (GameManager.Instance.buildingToPlace != null)
            {

                List<TileObject> iteratedTiles = new List<TileObject>();

                //Flag for checking if we are able to build in here.
                bool canPlaceBuildingHere = true;

                //Check adjacent tiles

                try
                {
                    for(int x = xPos; x < xPos + GameManager.Instance.buildingToPlace.data.width; x++)
                    {
                        if (canPlaceBuildingHere)
                        {
                            for (int z = zPos; z < zPos + GameManager.Instance.buildingToPlace.data.length; z++)
                            {
                                iteratedTiles.Add(GameManager.Instance.tileGrid[x,z]);

                                if (GameManager.Instance.tileGrid[x, z].data.IsOccupied)
                                {
                                    canPlaceBuildingHere = false;
                                    break;
                                }
                            
                            }
                        }
                    }

                }
                catch(System.IndexOutOfRangeException)
                {
                    Debug.Log("There were no tiles");
                    return;
                }


                if (canPlaceBuildingHere)
                {
                    GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);

                    //data.SetOccupied(Tile.ObstacleType.Building);
                }
                else
                {
                    Debug.Log("cannot place building");
                }
            }
            else
            {
                Debug.Log("building to place is null");
            }
        }
    }
}
