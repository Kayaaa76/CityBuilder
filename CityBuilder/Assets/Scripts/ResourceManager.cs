using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceManager : MonoBehaviour, IDataPersistence
{
    [Header("Resources")]

    [Space(8)]

    //Sets max amt of wood
    public int maxWood;
    int wood = 0;

    //Sets max amt of stone
    public int maxStone;
    int stone = 0;

    //Sets max amt of metal
    public int maxMetal;
    int metal = 0;

    //Sets max amt of Energy
    public int maxEnergy;
    int energy = 0;

    //Sets max amt of Standard Currency
    public int maxStandardCurr;
    int standardCurr = 0;

    //Sets max amt of Premium Currency
    public int maxPremiumCurr = 0;
    int premiumCurr = 0;

    public static ResourceManager Instance;

    public bool debugBool = false;

    public int Wood { get => wood; set => wood = value; }
    public int Stone { get => stone; set => stone = value; }
    public int Metal { get => metal; set => metal = value; }
    public int Energy { get => energy; set => energy = value; }
    public int StandardCurr { get => standardCurr; set => standardCurr = value; }
    public int PremiumCurr { get => premiumCurr; set => premiumCurr = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadData(GameData data)
    {
        this.Wood = data.wood;
        this.Stone = data.stone;
        this.Metal = data.metal;
        this.Energy = data.energy;
        this.StandardCurr = data.standardCurr;
        this.PremiumCurr = data.premiumCurr;
    }

    public void SaveData(ref GameData data) 
    {
        data.wood = this.Wood;
        data.stone = this.Stone;
        data.metal = this.Metal;
        data.energy = this.Energy;
        data.standardCurr = this.StandardCurr;
        data.premiumCurr = this.PremiumCurr;
    }

    private void Update()
    {
        if(debugBool)
        {
            PrintCurrentResources();    
            debugBool = false;
        }
    }

    /// <summary>
    /// Adds more wood to the inventory
    /// </summary>
    /// <param name="amount">Amount to add directly to out existing wood</param>
    public bool AddWood(int amount)
    {
        if ((wood + amount) <= maxWood)
        {
            Wood += amount;

            //Updates corresponding UI
            UIManager.Instance.UpdateWoodUI(Wood, maxWood);

            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseMaxWood(int amount)
    {
        maxWood += amount;
        UIManager.Instance.UpdateWoodUI(Wood, maxWood);
    }

    /// <summary>
    /// Adds more stone to the inventory
    /// </summary>
    /// <param name="amount">Amount to add directly to out existing stone</param>
    public bool AddStone(int amount) 
    {  
        if ((stone + amount) <= maxStone) 
        {
            Stone += amount;

            //Updates corresponding UI
            UIManager.Instance.UpdateStoneUI(Stone, maxStone);
            return true;        
        }
        else
        {
            return false;
        }   
    }

    public void IncreaseMaxStone(int amount)
    {
        maxStone += amount;
        UIManager.Instance.UpdateStoneUI(Stone, maxStone);
    }

    /// <summary>
    /// Adds more metal to the inventory
    /// </summary>
    /// <param name="amount">Amount to add directly to out existing metal</param>
    public bool AddMetal(int amount)
    {   
        if ((metal + amount) <= maxMetal)
        {
            Metal += amount;

            //Updates corresponding UI
            UIManager.Instance.UpdateMetalUI(Metal, maxMetal);

            return true;
        }
        else
        {
            return false;
        }  
    }

    public void IncreaseMaxMetal(int amount)
    {
        maxMetal += amount;
        UIManager.Instance.UpdateMetalUI(Metal, maxMetal);
    }

    /// <summary>
    /// Adds more energy to the inventory
    /// </summary>
    /// <param name="amount">Amount to add directly to out existing energy</param>
    public bool AddEnergy(int amount)
    {
        if ((energy + amount) <= maxEnergy)
        {
            Energy += amount;

            //Updates corresponding UI
            UIManager.Instance.UpdateEnergyUI(Energy, maxEnergy);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseMaxEnergy(int amount)
    {
        maxWood += amount;
        UIManager.Instance.UpdateEnergyUI(Energy, maxEnergy);
    }

    /// <summary>
    /// Adds more Standard currency to the inventory
    /// </summary>
    /// <param name="amount">Amount to add directly to out existing Standard Currency</param>
    public bool AddStandardCurr(int amount)
    {
        if ((StandardCurr + amount) <= maxStandardCurr)
        {   
            StandardCurr += amount;

            //Updates corresponding UI
            UIManager.Instance.UpdateStandardUI(StandardCurr, maxStandardCurr);

            return true;
        }
        else
        {
            return false;
        }     
    }

    /// <summary>
    /// Adds more Premium Currency to the inventory
    /// </summary>
    /// <param name="amount">Amount to add directly to out existing Premium Currency</param>
    public bool AddPremiumCurr(int amount)
    {
        if ((premiumCurr + amount) <= maxPremiumCurr)
        {
            PremiumCurr += amount;

            //Updates corresponding UI
            UIManager.Instance.UpdatePremiumUI(PremiumCurr, maxPremiumCurr);

            return true;
        }
        else
        {
            return false;
        }        
    }

    void PrintCurrentResources()
    {
        Debug.Log("wood" + Wood);
        Debug.Log("stone" + Stone);
        Debug.Log("metal" + Metal);
        Debug.Log("energy" + Energy);   
        Debug.Log("standard" + StandardCurr); 
        Debug.Log("premium" + PremiumCurr);
    }
}
