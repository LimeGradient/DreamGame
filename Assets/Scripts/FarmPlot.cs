using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    public List<GameObject> crops = new List<GameObject>();

    public bool isGrown;

    private bool isTallPlant;

    private int i;

    public string cropType;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in transform)
        {
            if (t.name.Contains("Cabbage"))
            {
                crops.Add(t.gameObject);
                isTallPlant = false;
                cropType = "Cabbage";
            }

            if (t.name.Contains("Tomato"))
            {
                crops.Add(t.gameObject);
                isTallPlant = true;
                cropType = "Tomato";
            }   
        }
    }

    private void Update()
    {
        foreach (GameObject g in crops)
        {
            if (!isTallPlant)
            {
                if (g.transform.localScale == new Vector3(1, 1, 1))
                {
                    isGrown = true;
                }
                else
                {
                    isGrown = false;
                }
            }

            if (isTallPlant)
            {
                if (g.transform.localScale == new Vector3(2.15f, 2.15f, 2.15f))
                {
                    isGrown = true;
                }
                else
                {
                    isGrown = false;
                }
            }
        }
    }

    public IEnumerator growCrops() // Tomato Plants Scale is always 2.15
    { // Divded that by 4 is 0.5375
        if (!isTallPlant)
        {
            foreach (GameObject g in crops)
            {
                g.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
            }
        }

        if (isTallPlant)
        {
            foreach (GameObject g in crops)
            {
                g.transform.localScale += new Vector3(0.5375f, 0.5375f, 0.5375f);
            }
        }

        i++;
        print(i);
        if (i == 4)
        {
            i = 0;
            yield break;
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(growCrops());
    }

    public void ResetCrops()
    {
        foreach (GameObject g in crops)
        {
            g.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
