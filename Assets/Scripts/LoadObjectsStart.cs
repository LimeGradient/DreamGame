using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadObjectsStart : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] ores;
    public GameObject[] farmPlots;

    [Range(1, 6000)] public int spawnRange;

    public AudioMixer game;

    public AudioMixer music;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.fieldOfView = PlayerPrefs.GetFloat("fov");
        game.SetFloat("Volume", (-80 + PlayerPrefs.GetFloat("gameVol") * 100));
        music.SetFloat("Volume", (-80 + PlayerPrefs.GetFloat("musicVol") * 100));
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
            GameObject _ore = Instantiate(ores[Random.Range(0, ores.Length)], newSpawnPos(), Quaternion.identity);
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
            GameObject _farmPlot = Instantiate(farmPlots[Random.Range(0, farmPlots.Length)], newSpawnPos(), Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(_farmPlot.transform.position, Vector3.down, out hit))
            {
                Transform _farmPlotTransform = _farmPlot.transform;
                _farmPlotTransform.position = new Vector3(_farmPlotTransform.position.x,
                    hit.point.y + 2, _farmPlotTransform.position.z);
                _farmPlotTransform.Rotate(new Vector3(_farmPlotTransform.rotation.x, _farmPlotTransform.rotation.y, FindTerrainHillAngle(_farmPlotTransform)));
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

    float FindTerrainHillAngle(Transform t)
    {
        RaycastHit front;
        RaycastHit down;

        float frontLength = 0f;
        float downLength = 0f;

        if (Physics.Raycast(t.position, Vector3.forward, out front, 10f))
        {
            frontLength = front.distance;
        }

        if (Physics.Raycast(t.position, Vector3.down, out down, 10f))
        {
            downLength = down.distance;
        }

        print(frontLength + " " + downLength);
        return Mathf.Atan(frontLength / downLength);
    }

    void GenerateForest()
    {
        Vector3 centerForestPos = newSpawnPos();
        for (int i = 0; i < spawnRange; i++)
        {
            var rad = 2 * Mathf.PI / spawnRange * i;
            var vert = Mathf.Sin(rad);
            var horz = Mathf.Cos(rad);

            var spawnDir = new Vector3(horz, 0, vert);
            var spawnPos = centerForestPos + spawnDir * rad;

            var tree = Instantiate(trees[Random.Range(0, trees.Length)], spawnPos, Quaternion.identity) as GameObject;
            RaycastHit hit;
            if (Physics.Raycast(tree.transform.position, Vector3.down, out hit))
            {
                Transform _treeTransform = tree.transform;
                _treeTransform.position =
                    new Vector3(_treeTransform.position.x, hit.point.y - 1, _treeTransform.position.z);
            }
            else
            {
                Destroy(tree);
            }
        }
    }
}
