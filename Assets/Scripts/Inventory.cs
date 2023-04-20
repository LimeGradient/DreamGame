using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public int wood;
    [HideInInspector] public int stone;
    [HideInInspector] public int sulfur;
    [HideInInspector] public int quartz;
    [HideInInspector] public int coal;
    [HideInInspector] public int cabbage;
    [HideInInspector] public int cabbageSeeds;
    [HideInInspector] public int tomato;
    [HideInInspector] public int tomatoSeeds;

    public InventoryManager InventoryManager;

    private void Start()
    {
        cabbageSeeds = 24;
        tomatoSeeds = 24;
    }

    private void Update()
    {
        //InventoryManager.items[0].count = cabbage;
        //InventoryManager.items[1].count = tomato;
        //InventoryManager.items[2].count = stone;
    }
}
