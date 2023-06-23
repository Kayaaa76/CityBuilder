using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour, IDataPersistence
{

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        //strings of 32 char that extremely high probability of being unique
        id = System.Guid.NewGuid().ToString();
    }    

    public ObstacleType obstacleType;
    public int resourceAmount = 10;
    TileObject refTile;

    //onClick Event
    bool usedResource = false;



    public void LoadData(GameData data)
    {
        data.obstacleObjectCollected.TryGetValue(id, out usedResource);
        if (usedResource)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(ref GameData data) 
    {
        if(data.obstacleObjectCollected.ContainsKey(id))
        {
            data.obstacleObjectCollected.Remove(id);
        }
        data.obstacleObjectCollected.Add(id, usedResource);
    
    }

    /// <summary>
    /// This method is called whenever item is tapped/clicked
    /// works on Mobile/PC
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log(obstacleType);

        ////onClick Event
        //bool usedResource = false;

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
