using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRuntimeTerrain : MonoBehaviour
{
    public GameObject[] treeProtos;
    // Start is called before the first frame update
    void Start()
    {
        var terrain = GetComponent<Terrain>().terrainData;
        foreach (var instance in terrain.treeInstances)
        {
            var tree = Instantiate(treeProtos[instance.prototypeIndex], instance.position,
                Quaternion.Euler(0, Mathf.Rad2Deg * instance.rotation, 0), transform);
            tree.transform.localScale = new Vector3(instance.widthScale, instance.heightScale, instance.widthScale);
        }

        terrain.treeInstances = new TreeInstance[0];
    }
}
