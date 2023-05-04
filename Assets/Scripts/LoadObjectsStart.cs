using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjectsStart : MonoBehaviour
{
    public GameObject[] trees;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Random.Range(7400, 7500); i++)
        {
            print(i);
            GameObject _tree = Instantiate(trees[Random.Range(1, 2)], newSpawnPos(), Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(_tree.transform.position, Vector3.down, out hit))
            {
                Transform _treeTransform = _tree.transform;
                _treeTransform.position =
                    new Vector3(_treeTransform.position.x, hit.point.y - 1, _treeTransform.position.z);
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 newSpawnPos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(10, 1000), 500, Random.Range(10, 1000));
        return spawnPos;
    }
}
