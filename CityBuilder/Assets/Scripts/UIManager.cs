using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]

    [Space(8)]

    //Ref for containers
    public StandardUIReference woodUI;
    public StandardUIReference stoneUI;
    public StandardUIReference metalUI;
    public StandardUIReference energyUI;
    public StandardUIReference standardUI;
    public StandardUIReference premiumUI;

    //Instance handling for singleton
    public static UIManager Instance;

    private void Awake()
    {
        //Initialising singleton pattern (not for production)
        Instance = this;
    }

    private void Start()
    {
        UpdateAll();
    }

    /// <summary>
    /// Updates wood UI
    /// </summary>
    /// <param name="currentAmt">sets current amt of the slider and txt</param>
    /// <param name="maxAmt">sets max amt of the slider and txt</param>
    public void UpdateWoodUI(int currentAmt, int maxAmt)
    {
        //Set txt in UI
        woodUI.currentUI.text = currentAmt.ToString();
        woodUI.maxUI.text = "MAX: " + maxAmt.ToString();

        //Set the slider
        woodUI.slider.maxValue = maxAmt;
        woodUI.slider.value = currentAmt;  
    }

    /// <summary>
    /// Updates stone UI
    /// </summary>
    /// <param name="currentAmt">sets current amt of the slider and txt</param>
    /// <param name="maxAmt">sets max amt of the slider and txt</param>
    public void UpdateStoneUI(int currentAmt, int maxAmt)
    {
        //Set txt in UI
        stoneUI.currentUI.text = currentAmt.ToString();
        stoneUI.maxUI.text = "MAX: " + maxAmt.ToString();

        //Set the slider
        stoneUI.slider.maxValue = maxAmt;
        stoneUI.slider.value = currentAmt;
    }

    /// <summary>
    /// Updates metal UI
    /// </summary>
    /// <param name="currentAmt">sets current amt of the slider and txt</param>
    /// <param name="maxAmt">sets max amt of the slider and txt</param>
    public void UpdateMetalUI(int currentAmt, int maxAmt)
    {
        //Set txt in UI
        metalUI.currentUI.text = currentAmt.ToString();
        metalUI.maxUI.text = "MAX: " + maxAmt.ToString();

        //Set the slider
        metalUI.slider.maxValue = maxAmt;
        metalUI.slider.value = currentAmt;
    }

    /// <summary>
    /// Updates energy UI
    /// </summary>
    /// <param name="currentAmt">sets current amt of the slider and txt</param>
    /// <param name="maxAmt">sets max amt of the slider and txt</param>
    public void UpdateEnergyUI(int currentAmt, int maxAmt)
    {
        //Set txt in UI
        energyUI.currentUI.text = currentAmt.ToString();
        energyUI.maxUI.text = "MAX: " + maxAmt.ToString();

        //Set the slider
        energyUI.slider.maxValue = maxAmt;
        energyUI.slider.value = currentAmt;
    }

    /// <summary>
    /// Updates Standard Currency UI
    /// </summary>
    /// <param name="currentAmt">sets current amt of the slider and txt</param>
    /// <param name="maxAmt">sets max amt of the slider and txt</param>
    public void UpdateStandardUI(int currentAmt, int maxAmt)
    {
        //Set txt in UI
        standardUI.currentUI.text = currentAmt.ToString();
        standardUI.maxUI.text = "MAX: " + maxAmt.ToString();

        //Set the slider
        standardUI.slider.maxValue = maxAmt;
        standardUI.slider.value = currentAmt;
    }

    /// <summary>
    /// Updates Premium Currency UI
    /// </summary>
    /// <param name="currentAmt">sets current amt of the slider and txt</param>
    /// <param name="maxAmt">sets max amt of the slider and txt</param>
    public void UpdatePremiumUI(int currentAmt, int maxAmt)
    {
        //Set txt in UI
        premiumUI.currentUI.text = currentAmt.ToString();
        premiumUI.maxUI.text = "MAX: " + maxAmt.ToString();

        //Set the slider
        premiumUI.slider.maxValue = maxAmt;
        premiumUI.slider.value = currentAmt;
    }


    void UpdateAll()
    {
        UpdateWoodUI(ResourceManager.Instance.Wood, ResourceManager.Instance.maxWood);
        UpdateStoneUI(ResourceManager.Instance.Stone, ResourceManager.Instance.maxStone);
        UpdateMetalUI(ResourceManager.Instance.Metal, ResourceManager.Instance.maxMetal);
        UpdateEnergyUI(ResourceManager.Instance.Energy, ResourceManager.Instance.maxEnergy);
        UpdateStandardUI(ResourceManager.Instance.StandardCurr, ResourceManager.Instance.maxStandardCurr);
        UpdatePremiumUI(ResourceManager.Instance.PremiumCurr, ResourceManager.Instance.maxPremiumCurr);
    }
}

//Main Class for setting up containers
[System.Serializable]
public class StandardUIReference
{
    public Slider slider;
    public TextMeshProUGUI maxUI;
    public TextMeshProUGUI currentUI;
}
