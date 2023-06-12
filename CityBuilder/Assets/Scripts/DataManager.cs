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
    public void AddItem(GameObject gameobj)
    {
    }



}
[System.Serializable]
public class ItemDB
{
    public List<Item> items = new List<Item>(); 
}

[System.Serializable]
public class Item
{
    public string Name;
    public string Description;
    public Vector3 Position;
}
