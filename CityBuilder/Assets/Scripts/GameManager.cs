using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]

    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 0.85f;

    [Space(8)]

    //This grid directly stores all the info
    public TileObject[,] tileGrid = new TileObject[0,0];

    [Header("Resources")]

    [Space(8)]

    public GameObject woodPrefab;
    public GameObject stonePrefab;
    public Transform resourcesHolder;


    [Range(0f, 1f)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;

    [Space(8)]

    //Debug method (selected building)
    public BuildingObject buildingToPlace;

    public static GameManager Instance { get; set; }

    private void Awake()
    {
        Instance = this; 
    }
    public void Start()
    {
        CreateLevel();
    }

    ///<summary>
    ///Create grid depending on player level width & length
    /// </summary>
    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();  

        for (int x = 0; x < levelWidth; x++) 
        {
            for (int z = 0; z < levelLength; z++) 
            {   
                //Directly spawns a tile
                TileObject spawnedTile  =  SpawnTile(x * tileSize, z * tileSize);

                //Sets TileObject world space data
                spawnedTile.xPos = x;
                spawnedTile.zPos = z;

                //Checks whenever we can spawn an obstacle a tile, using the bounds parameters
                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds)) 
                {
                    //Spawn obstacle in there.
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {   
                        spawnedTile.data.SetOccupied(Tile.ObstacleType.Resource);

                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);

                        tmpObstacle.SetTileReference(spawnedTile);
                    }
                }
                
                //Adds spawned visual tileobject inside list
                visualGrid.Add(spawnedTile);
            }
        }

        CreateGrid(visualGrid);
    }
    
    ///<summary>
    ///Spawns & returns tileObject
    ///</summary>
    ///<param name="xPos">XPosition inside the world</param>
    ///<param name="zPos">zPosition inside the world</param>
    ///<returns></returns> 
    TileObject SpawnTile(float xPos, float zPos)
    {   
        //Spawn Tile
        GameObject tempTile = Instantiate(tilePrefab);

        tempTile.transform.position = new Vector3(xPos, 0, zPos); 
        tempTile.transform.SetParent(tilesHolder);

        tempTile.name = "Tile" + xPos + " - " + zPos;

        //Check if tile is able to hold obstacle.


        //Todo: Make this to not get component
        return tempTile.GetComponent<TileObject>();
    }


    /// <summary>
    /// Will Spawn resource obstacle directly in coordinates
    /// </summary>
    /// <param name="xPos"></param>
    /// <param name="zPos"></param>
    ObstacleObject SpawnObstacle(float xPos, float zPos) 
    {
        //50% chance of spawning wood
        bool isWood = Random.value <= 0.5f;
        GameObject spawnedObstacle = null;

        //check if wood or stone obstacle is spawned
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
            spawnedObstacle.name = "Wood" + xPos + " - " + zPos;
        }
        else
        {
            spawnedObstacle= Instantiate(stonePrefab);
            spawnedObstacle.name = "Stone" + xPos + " - " + zPos;
        }

        //Sets pos and parent of spawned resource
        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        spawnedObstacle.transform.SetParent(resourcesHolder);

        return spawnedObstacle.GetComponent<ObstacleObject>();
    }


    /// <summary>
    /// Create tile grid to add building
    /// </summary>
    public void CreateGrid(List<TileObject> refVisualGrid)
    {
        //Set size of tile grid
        tileGrid = new TileObject[levelWidth, levelLength];

        //Iterates through all of the tile grid
        for (int x = 0; x < levelWidth; x++)
        {
            for(int z = 0; z < levelLength; z++)
            {
                //Connects tile grid directly to visual grid
                tileGrid[x,z] = refVisualGrid.Find(v => v.xPos == x && v.zPos == z);
                //Debug.Log(tileGrid[x,z].gameObject.name);
            }
        }
    }


    /// <summary>
    /// Handles placing system of the building
    /// </summary>
    /// <param name="building">Building to place</param>
    /// <param name="tile">Tile to place the building to</param>
    public void SpawnBuilding(BuildingObject building, List<TileObject> tiles)
    {
        GameObject spawnedBuilding = Instantiate(building.gameObject);
        float sumX = 0;
        float sumZ = 0;

        //Sum value of X pos of all tiles
        //Sum value of Z pos of all tiles
        for (int i = 0; i < tiles.Count; i++) 
        {
            sumX += tiles[i].xPos;
            sumZ += tiles[i].zPos;

            tiles[i].data.SetOccupied(Tile.ObstacleType.Building, spawnedBuilding.GetComponent<BuildingObject>());
            //Debug.Log("placed building in" + tiles[i].xPos + " - " + tiles[i].zPos);
            
        }
        Vector3 position = new Vector3((sumX/tiles.Count), building.data.yPadding, (sumZ/tiles.Count));

        spawnedBuilding.transform.position = position;
    }

    public void SelectBuilding(int id)
    {
        for(int i=0; i<BuildingDatabase.Instance.buildingDatabase.Count; i++)
        {
            if (BuildingDatabase.Instance.buildingDatabase[i].buildingID == id)
            {
                buildingToPlace = BuildingDatabase.Instance.buildingDatabase[i].refOfBuilding;
            }
        }
    }
}
