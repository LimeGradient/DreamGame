using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODOptimization : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LODGroup lodGroup = GetComponent<LODGroup>();
        if (lodGroup != null)
        {
            Transform lodTransform = lodGroup.transform;
            foreach (Transform child in lodTransform)
            {
                var renderer = child.GetComponent<Renderer>();
                if (renderer != null && renderer.isVisible)
                {
                    int i = 0;
                }
                else
                {
                    Collider col = GetComponent<CapsuleCollider>();
                    col.enabled = false;
                }
            }
        }
    }
}
