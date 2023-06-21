using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; set; }
    public ItemDB ItemDB;

    private void Start()
    {
        instance = this;
    }
    //public void AddItem(GameObject gameobj)
    //{
    //    Item item = new Item();
    //    item.PrefabID = Builder.Instance.SelectedObject;
    //    item.ItemID = item.PrefabID + ItemDB.items.Count + ToString();
    //    gameobj.name = item.ItemID;
    //    item.Position = gameobj.transform.position;
    //    ItemDB.items.Add(item);
    //}

    //public void RemoveItem(string itemId)
    //{
    //    Item item -ItemDB.items.Where(p => p.ItemID == itemId).First();
    //    ItemDB.items.Remove(item);
    //}

    //public void SaveData()
    //{
    //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(BuildingDatabase));
    //    FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data.xml", FileMode.Create);
    //    xmlSerializer.Serialize(stream, BuildingDatabase.Instance);
    //    stream.Close();
    //}

    //void LoadData()
    //{
    //    if (!File.Exists(Application.dataPath + "/StreamFiles/Game_data.xml")) return;
    //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(BuildingDatabase));
    //    FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data.xml", FileMode.Open);
    //    BuildingDatabase.Instance = xmlSerializer.Deserialize(stream) as BuildingDatabase;
    //    stream.Close();

    //    foreach (Building building in BuildingDatabase.Instance.buildingDatabase)
    //    {
    //        GameObject go = Instantiate(buildingToPlace.RequestBuildingPrefab(building.buildingID), buildingToPlace.transform.position, Quaternion.identity);
    //        go.name = building.buildingID.ToString();
    //    }
    //}

}
[System.Serializable]
public class ItemDB
{
    public List<Item> items = new List<Item>(); 
}

[System.Serializable]
public class Item
{
    public string PrefabID;
    public string ItemID;
    public Vector3 Position;
}
