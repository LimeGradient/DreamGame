using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDurability : MonoBehaviour
{
    public int durability = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            durability--;
        }

        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
