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

    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {

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
        }
    }

    IEnumerator CreateResource() 
    {
        while(true)
        {
            if(resource < resourceLimit)
            {
                resource +=  generationSpeed * Time.deltaTime;
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
