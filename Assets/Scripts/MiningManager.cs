using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class MiningManager : MonoBehaviour
{
    private ToolSwitch ts;

    private Inventory inv;

    public float hitRange = 2.5f; // How far away before cant hit
    public int damage = 1; // How much damage mining should do
    
    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponent<ToolSwitch>();
        inv = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue);
        if (Input.GetKeyDown(KeyCode.Mouse0) && ts.pickaxeActive())
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
                    hitRange))
            {
                if (!hit.transform.GetComponent<Ore>())
                {
                    return;
                }
                hit.transform.GetComponent<Ore>().health -= damage;

                if (hit.transform.CompareTag("Coal"))
                {
                    inv.coal += Random.Range(1, 5);
                }

                if (hit.transform.CompareTag("Sulfur"))
                {
                    inv.sulfur += Random.Range(1, 5);
                }

                if (hit.transform.CompareTag("Quartz"))
                {
                    inv.quartz += Random.Range(1, 5);
                }

                if (hit.transform.CompareTag("Stone"))
                {
                    inv.stone += Random.Range(1, 5);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && ts.axeActive())
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, hitRange))
            {
                if (!hit.transform.GetComponent<Ore>())
                {
                    return;
                }

                hit.transform.GetComponent<Ore>().health -= damage;

                if (hit.transform.CompareTag("Tree"))
                {
                    inv.wood += Random.Range(1, 5);
                }
            }
        }
    }
}
