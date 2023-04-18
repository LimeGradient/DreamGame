using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Image>().sprite)
        {
            GetComponentInChildren<Text>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
