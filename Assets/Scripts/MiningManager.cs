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
    [SerializeField] private HeldItem heldItem;
    [SerializeField] private SC_FPSController fpsController;

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

        foreach (Transform t in Camera.main.transform)
        {
            if (t.CompareTag("Pickaxe")) ts.PickaxeActive = true;
            else ts.PickaxeActive = false;
        }

        if (Input.GetMouseButtonDown(0) && fpsController.canMove)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
                    hitRange))
            {

                if (hit.transform.GetComponent<Ore>().health == 0)
                {
                    hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    hit.transform.GetComponent<Rigidbody>().AddForce(new Vector3(20, 20, 0), ForceMode.Impulse);
                    return;
                }
                if (!hit.transform.GetComponent<Ore>())
                {
                    Debug.LogError("No Ore Script found at " + hit.transform.name);
                    return;
                }
                if (hit.transform.CompareTag("Stone") && heldItem.heldItemId == 4)
                {
                    //inv.stone += Random.Range(1, 5);
                    //invMan.items[2].count += Random.Range(1, 5);
                    invMan.AddItemToInventory(2, Random.Range(1, 5));
                    hit.transform.GetComponent<Ore>().AdjustHealth(1);
                    Instantiate(explosion, hit.point, transform.rotation);
                }
                if (hit.transform.CompareTag("Quartz") && heldItem.heldItemId == 4)
                {
                    //inv.quartz += Random.Range(1, 5);
                    invMan.AddItemToInventory(6, Random.Range(1, 5));
                    hit.transform.GetComponent<Ore>().AdjustHealth(1);
                    Instantiate(explosion, hit.point, transform.rotation);
                }
                if (hit.transform.CompareTag("Sulfur") && heldItem.heldItemId == 4)
                {
                    //inv.sulfur += Random.Range(1, 5);
                    invMan.AddItemToInventory(7, Random.Range(1, 5));
                    hit.transform.GetComponent<Ore>().AdjustHealth(1);
                    Instantiate(explosion, hit.point, transform.rotation);
                }
                if (hit.transform.CompareTag("Coal") && heldItem.heldItemId == 4)
                {
                    //inv.coal += Random.Range(1, 5);
                    invMan.AddItemToInventory(5, Random.Range(1, 5));
                    hit.transform.GetComponent<Ore>().AdjustHealth(1);
                    Instantiate(explosion, hit.point, transform.rotation);
                }

                if (hit.transform.CompareTag("Tree") && heldItem.heldItemId == 3)
                {
                    //inv.wood += Random.Range(1, 5);
                    invMan.AddItemToInventory(8, Random.Range(1, 5));
                    hit.transform.GetComponent<Ore>().AdjustHealth(1);
                    Instantiate(explosion, hit.point, transform.rotation);
                }
            
            }
        }
    }
}
