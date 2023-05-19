using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTool : MonoBehaviour
{
    private GameObject currentObj;
    private GameObject currentPrev;
    [SerializeField] private GameObject rayOrigin;
    [SerializeField] private bool isBuilding;
    public GameObject[] buildObj;
    public GameObject player;
    private int buildObjIndex;
    [SerializeField] private GameObject[] objPrev;

    public Material buildMat;
    public Material defaultMat;
    public Material defaultFarmMat;

    private KeyCode[] keys =
    {
        KeyCode.Alpha0,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuilding = !isBuilding;
            player.GetComponent<ToolSwitch>().enabled = !player.GetComponent<ToolSwitch>().enabled;
        }
        
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hit) && isBuilding)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]) && isBuilding)
                {
                    buildObjIndex = i-1;
                    currentPrev.transform.position = new Vector3(0, -100, 0);
                }
            }

            currentPrev = objPrev[buildObjIndex];
            if (!currentPrev.GetComponent<Renderer>())
            {
                currentPrev.AddComponent<MeshRenderer>();
            }
            currentPrev.GetComponent<Renderer>().material = buildMat;
            foreach (Transform t in currentPrev.transform)
            {
                if (!t.GetComponent<Collider>())
                {
                    continue;
                }
                t.GetComponent<Renderer>().material = buildMat;
                t.GetComponent<Collider>().enabled = false;
            }
            currentPrev.transform.position = hit.point;
            Quaternion currentRot;
            currentRot = currentPrev.transform.rotation;
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentPrev.transform.Rotate(new Vector3(0, 90, 0));
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentObj = Instantiate(buildObj[buildObjIndex], hit.point, currentRot);
                currentObj.GetComponent<Renderer>().material = defaultMat;
                foreach (Transform t in currentObj.transform)
                {
                    t.GetComponent<Renderer>().material = defaultMat;
                }
                print(currentObj.name);
            }
        }
    }
}
