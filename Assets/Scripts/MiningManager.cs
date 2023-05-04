using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;

public class MiningManager : MonoBehaviour
{
    private ToolSwitch ts;
    private Inventory inv;
    [SerializeField] private InventoryManager invMan;

    public GameObject explosion;

    public float hitRange = 2.5f; // How far away before cant hit
    public int damage = 1; // How much damage mining should do
    
    // Start is called before the first frame update
    void Start()
    {
        inv = GetComponent<Inventory>();
        ts = GetComponent<ToolSwitch>();
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
                hit.transform.GetComponent<Ore>().gayfurryfemboyhitler(1);
                Instantiate(explosion, hit.point, transform.rotation);

                if (hit.transform.CompareTag("Stone") && ts.pickaxeActive())
                {
                    //inv.stone += Random.Range(1, 5);
                    invMan.items[2].count += Random.Range(1, 5);
                }
                if (hit.transform.CompareTag("Quartz") && ts.pickaxeActive())
                {
                    inv.quartz += Random.Range(1, 5);
                }
                if (hit.transform.CompareTag("Sulfur") && ts.pickaxeActive())
                {
                    inv.sulfur += Random.Range(1, 5);
                }
                if (hit.transform.CompareTag("Coal") && ts.pickaxeActive())
                {
                    inv.coal += Random.Range(1, 5);
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
                    Debug.LogError("No Ore Script found at " + hit.transform.name);
                    return;
                }

                hit.transform.GetComponent<Ore>().gayfurryfemboyhitler(1);
                Instantiate(explosion, hit.point, transform.rotation);
                if (hit.transform.GetComponent<Ore>().health == 0)
                {
                    hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    hit.transform.GetComponent<Rigidbody>().AddForce(new Vector3(20, 20, 0), ForceMode.Impulse);
                }

                if (hit.transform.GetComponent<Ore>().health != 0)
                {
                    if (hit.transform.CompareTag("Tree") && ts.axeActive())
                    {
                        inv.wood += Random.Range(1, 5);
                    }
                }
            }
        }
    }
}
