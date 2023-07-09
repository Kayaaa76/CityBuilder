using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObject : MonoBehaviour, IDataPersistence
{
    public Building data;

    public float currentlevel = 1;

    [Header("Resource Generation")]
    [Space(8)]

    //resource created by building
    public float resource = 0;

    //Max limit building can generate its resource
    public float baseResourceLimit = 100;

    public float currentResourceLimit;

    //Speed that the resource generate
    public float generationSpeed = 0.25f;

    [Header("Resource Storage")]
    [Space(8)]

    public float currentStorageLimit;

    [Header("UI")]
    [Space(8)]

    public GameObject canvasObject;
    public Slider progressSlider;
    bool upgradeBuilding;


    Coroutine buildingBehaviour;

    private void Start()
    {
        currentResourceLimit = baseResourceLimit * currentlevel;

        if(data.buildingType == Building.BuildingType.Resource) 
        {
            //Increment resource
            buildingBehaviour = StartCoroutine(CreateResource());
        }

        if(data.buildingType == Building.BuildingType.Storage)
        {
            IncreaseMaxStorage();
            canvasObject.SetActive(false);
        } 
    }

    public void LoadData(GameData gameData)
    {
        data.buildinglevel = gameData.buildingLevel;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.buildingLevel = data.buildinglevel;
    }

    private void TownHallController()
    {
        if(data.buildingType == Building.BuildingType.TownHall)
        {
            

        }
        

    }


    private void OnMouseDown()
    {
        //Collecting of resources
        if (data.buildingType == Building.BuildingType.Storage)
            return;

        switch(data.resourceType)
        {
            case Building.ResourceType.Wood:
                ResourceManager.Instance.AddWood((int)resource);
                break;
            case Building.ResourceType.Stone:
                ResourceManager.Instance.AddStone((int)resource);
                break;
            case Building.ResourceType.Metal:
                ResourceManager.Instance.AddMetal((int)resource);
                break;
            case Building.ResourceType.Energy:
                ResourceManager.Instance.AddEnergy((int)resource);
                break;
            case Building.ResourceType.Standard:
                ResourceManager.Instance.AddStandardCurr((int)resource);
                break;
        }
        EmptyResource();
    }
    #region ResouceBuilding
    void EmptyResource()
    {
        resource = 0;
    }

    void IncreaseMaxStorage()
    {
        switch (data.resourceType)
        {
            case Building.ResourceType.Wood:
                ResourceManager.Instance.IncreaseMaxWood((int)resource);    
                break;
            case Building.ResourceType.Stone:
                ResourceManager.Instance.IncreaseMaxStone((int)resource);
                break;
            case Building.ResourceType.Metal:
                ResourceManager.Instance.IncreaseMaxMetal((int)resource);
                break;
            case Building.ResourceType.Energy:
                ResourceManager.Instance.IncreaseMaxEnergy((int)resource);
                break;
        }
    }


    IEnumerator CreateResource() 
    {
        while(true)
        {
            if(resource < currentResourceLimit)
            {
                resource +=  generationSpeed * currentlevel * Time.deltaTime;
            }
            else
            {
                resource = currentResourceLimit;
            }
            UpdateUI(resource, currentResourceLimit);

            yield return null;
        }
    }
    
    void BuildingLevel()
    {
        switch (data.buildinglevel)
        {
            case 1:
                break;
            case 2:
                break;
        }
    }
    #endregion


    public void UpdateUI(float current, float maxValue)
    {
        progressSlider.value = current;
        progressSlider.maxValue = maxValue; 
    }
}
