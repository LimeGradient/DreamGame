using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AngstyTeen.JSON;
using AngstyTeen.GameDirectory;

public class SaveTest : MonoBehaviour
{
    private JSON json = new JSON();
    // Start is called before the first frame update
    void Start()
    {
        json.CreateLevelSave(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            json.SaveLevel(1);
        }
    }
}