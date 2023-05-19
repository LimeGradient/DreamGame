using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjectsStart : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] ores;
    public GameObject[] farmPlots;

    [Range(1, 6000)] public int spawnRange;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Random.Range(spawnRange, spawnRange + 100); i++)
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
            else
            {
                Destroy(_tree);
            }
        }

        for (int i = 0; i < Random.Range(spawnRange - 3000, spawnRange - 2900); i++)
        {
            GameObject _ore = Instantiate(ores[Random.Range(1, 3)], newSpawnPos(), Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(_ore.transform.position, Vector3.down, out hit))
            {
                Transform _oreTransform = _ore.transform;
                _oreTransform.position =
                    new Vector3(_oreTransform.position.x, hit.point.y, _oreTransform.position.z);
                if (_ore.layer == 6)
                {
                    Vector3 rot = new Vector3(_ore.transform.rotation.x, Random.Range(10, 180),
                        _ore.transform.rotation.z);
                    _ore.transform.Rotate(rot);
                }
            }
            else
            {
                Destroy(_ore);
            }
        }

        for (int i = 0; i < Random.Range(spawnRange - 4000, spawnRange - 3900); i++)
        {
            GameObject _farmPlot = Instantiate(farmPlots[Random.Range(1, 2)], newSpawnPos(), Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(_farmPlot.transform.position, Vector3.down, out hit))
            {
                Transform _farmPlotTransform = _farmPlot.transform;
                _farmPlotTransform.position = new Vector3(_farmPlotTransform.position.x,
                    hit.point.y + 2, _farmPlotTransform.position.z);
                print(hit.transform.rotation);
            }
            else
            {
                Destroy(_farmPlot);
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
