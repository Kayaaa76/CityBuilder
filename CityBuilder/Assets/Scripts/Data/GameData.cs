using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int wood;
    public int stone;
    public int metal;
    public int energy;
    public int standardCurr;
    public int premiumCurr;

    public GameData()
    {
        this.wood = 0;
        this.stone = 0;
        this.metal = 0;
        this.energy = 0;
        this.standardCurr = 0;
        this.premiumCurr = 0;
    }
}
