using System.Collections;
using System.Collections.Generic;
using AngstyTeen.Core;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Important Player Vars
    public string playerID()
    {
        return $"playerid{Core.TripleZeroRandomNum().ToString()}";
    }
    
    [Header("Farming")]
    
    // Crops
    public int cabbage;
    public int tomatoes;
    
    // Seeds
    public int cabbageSeeds;
    public int tomatoSeeds;

    [Header("Mining")] 
    // Ores
    public int coal;
    public int sulfur;
    public int quartz;
}

namespace AngstyTeen.Core
{
    public class Core
    {
        public static int TripleZeroRandomNum()
        {
            return Random.Range(100, 999);
        }
    }
}