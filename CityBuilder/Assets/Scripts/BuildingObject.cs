using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObject : MonoBehaviour, IDataPersistence
{
    public Building data;

    [Header("Resource Generation")]
    [Space(8)]

    //resource created by building
    public float resource = 0;

    //Max limit building can generate its resource
    public float resourceLimit = 100;

    //Speed that the resource generate
    public float generationSpeed = 0.25f;

    public float levelMultiplier;


    [Header("UI")]
    [Space(8)]

    public GameObject canvasObject;
    public Slider progressSlider;

    Coroutine buildingBehaviour;

    private void Start()
    {
        if(data.resourceType == Building.ResourceType.Standard || data.resourceType == Building.ResourceType.Premium)
        {
            //Increment resource
            buildingBehaviour = StartCoroutine(CreateResource());
        }

        if(data.resourceType == Building.ResourceType.Storage)
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

    private void OnMouseDown()
    {
        if (data.resourceType == Building.ResourceType.Storage)
            return;

        switch(data.resourceType)
        {
            case Building.ResourceType.Standard:
                ResourceManager.Instance.AddStandardCurr((int)resource);
                break;

            case Building.ResourceType type:
                ResourceManager.Instance.AddPremiumCurr((int)resource);
                break;
        }

        EmptyResource();
    }

    void EmptyResource()
    {
        resource = 0;
    }

    void IncreaseMaxStorage()
    {
        switch (data.storageType)
        {
            case Building.StorageType.Wood:
                ResourceManager.Instance.IncreaseMaxWood((int)resource);    
                break;
            case Building.StorageType.Stone:
                ResourceManager.Instance.IncreaseMaxStone((int)resource);
                break;
            case Building.StorageType.Metal:
                ResourceManager.Instance.IncreaseMaxMetal((int)resource);
                break;
            case Building.StorageType.Energy:
                ResourceManager.Instance.IncreaseMaxEnergy((int)resource);
                break;
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

    IEnumerator CreateResource() 
    {
        while(true)
        {
            if(resource < resourceLimit)
            {
                resource +=  generationSpeed * levelMultiplier * Time.deltaTime;
            }
            else
            {
                resource = resourceLimit;
            }
            UpdateUI(resource, resourceLimit);

            yield return null;
        }
    }

    public void UpdateUI(float current, float maxValue)
    {
        progressSlider.value = current;
        progressSlider.maxValue = maxValue; 
    }
}
