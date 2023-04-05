using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{
    public GameObject[] tools;

    private void Start()
    {
        ResetTools();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetTools();
            tools[0].SetActive(true);
            ToolInSlot(tools[0]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ResetTools();
            tools[1].SetActive(true);
            ToolInSlot(tools[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ResetTools();
            tools[2].SetActive(true);
            ToolInSlot(tools[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ResetTools();
            tools[3].SetActive(true);
            ToolInSlot(tools[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetTools();
            tools[4].SetActive(true);
            ToolInSlot(tools[4]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ResetTools();
            tools[5].SetActive(true);
            ToolInSlot(tools[5]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ResetTools();
            tools[6].SetActive(true);
            ToolInSlot(tools[6]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ResetTools();
            tools[7].SetActive(true);
            ToolInSlot(tools[7]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ResetTools();
            tools[8].SetActive(true);
            ToolInSlot(tools[8]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ResetTools();
            tools[9].SetActive(true);
            ToolInSlot(tools[9]);
        }
    }

    void ResetTools()
    {
        foreach (GameObject g in tools)
        {
            g.SetActive(false);
        }
    }

    bool ToolInSlot(GameObject g)
    {
        if (g != null)
        {
            return true;
        }
        else
        {
            ResetTools();
            return false;
        }
    }

    public bool axeActive()
    {
        foreach (GameObject g in tools)
        {
            if (g.name == "Axe" && g.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    public bool pickaxeActive()
    {
        foreach (GameObject g in tools)
        {
            if (g.name == "Pickaxe" && g.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }
}

