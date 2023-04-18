using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ore : MonoBehaviour
{
    public int health = 10;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            rb.constraints = RigidbodyConstraints.None;
            Destroy(gameObject, 5);
        }
    }
}
