using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    private bool isInPlot;
    private bool canFarm;

    private Collider c;

    private FarmPlot plot;
    private Inventory inv;

    private void Start()
    {
        inv = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (isInPlot)
        {
            Farm(c);
        }       
    }

    void Farm(Collider col)
    {
        if (col.CompareTag("FarmPlot"))
        {
            plot = col.GetComponent<FarmPlot>();
            if (Input.GetKeyDown(KeyCode.E) && plot.isGrown)
            {
                foreach (GameObject g in plot.crops)
                {
                    if (g.name.Contains("Cabbage"))
                    {
                        inv.cabbage++;
                    }

                    if (g.name.Contains("Tomato"))
                    {
                        inv.tomato++;
                    }
                    
                }
                plot.ResetCrops();
            }

            if (Input.GetKeyDown(KeyCode.E) && !plot.isGrown)
            {
                if (plot.cropType.Contains("Cabbage") && inv.cabbageSeeds != 0)
                {
                    inv.cabbageSeeds--;
                    StartCoroutine(plot.growCrops());
                }

                if (plot.cropType.Contains("Tomato") && inv.tomatoSeeds != 0)
                {
                    inv.tomatoSeeds--;
                    StartCoroutine(plot.growCrops());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FarmPlot"))
        {
            c = other;
            isInPlot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInPlot = false;
        c = null;
        plot = null;
    }
}