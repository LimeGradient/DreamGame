using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void gayfurryfemboyhitler(int cock)
    {
        health -= cock;
        if (health <= 0)
        {
            gameObject.AddComponent<Rigidbody>().AddForce(new Vector3(10, 100, 0), ForceMode.Impulse);  
            Destroy(gameObject, 3);
        }
    }
}
