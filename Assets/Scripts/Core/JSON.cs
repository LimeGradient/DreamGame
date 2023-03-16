using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

// I wrote all this code while angry
// if it doesnt work i will kms

// writing json is the bane of my existence

namespace AngstyTeen.JSON
{
    struct JSONObjectTemplate
    {
        public float xPos { get; set; }
        public float yPos { get; set; }
        public float zPos { get; set; }
        public string name { get; set; }
        public bool isChild { get; set; }
    }

    public class JSON : MonoBehaviour
    {
        private GameObject objManager;
        private Lime_Objects lo;
        public static string GamePath = "\\GameTest";

        private void Start()
        {
            objManager = GameObject.FindGameObjectWithTag("ObjectManager");
            lo = objManager.GetComponent<Lime_Objects>();
        }

        // this shit only for the actual scene not player
        public void CreateLevelSave(int saveNum)
        {
            Directory.CreateDirectory($"{GameDirectory.GameDirectory.GetAppDataFolder()}\\{GamePath}");
            File.Create(GameDirectory.GameDirectory.GetAppDataFolder() + $"\\{GamePath}\\level" + saveNum.ToString() +
                        ".json");
        }
        // ^ ditto
        public void SaveLevel(int saveNum)
        {
            GameObject[] allObj = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject g in allObj)
            {
                JSONObjectTemplate jsonTemplate = new JSONObjectTemplate()
                {
                    xPos = g.transform.position.x,
                    yPos = g.transform.position.y,
                    zPos = g.transform.position.z,
                    name = g.name,
                };
                if (g.transform.root != g.transform)
                {
                    jsonTemplate.isChild = true;
                }
                string jsonToWrite = JsonConvert.SerializeObject(jsonTemplate);
                print(jsonToWrite);
                string saveFilePath = GameDirectory.GameDirectory.GetLevelJSONFile(saveNum);
                using (StreamWriter sw = File.AppendText(saveFilePath))
                {
                    sw.WriteLine(jsonToWrite);
                }
            }
        }

        int findIndex(string target)
        {
            for (int i = 0; i < lo.allObjects.Length; i++)
            {
                if (lo.allObjects[i].name == target)
                {
                    return i;
                }
            }

            return -1;
        }
        
        public void LoadLevel(int saveNum)
        {
            Vector3 pos;
            foreach (string line in File.ReadLines($@"{GameDirectory.GameDirectory.GetLevelJSONFile(saveNum)}"))
            {
                JSONObjectTemplate jsonTemplate = JsonConvert.DeserializeObject<JSONObjectTemplate>(line);
                if (jsonTemplate.name.Contains("FarmPlot"))
                {
                    if (jsonTemplate.name.Contains("Lettuce"))
                    {
                        int i = findIndex("FarmPlot_Lettuce");
                        pos.x = jsonTemplate.xPos;
                        pos.y = jsonTemplate.yPos;
                        pos.z = jsonTemplate.zPos;
                        Instantiate(lo.allObjects[i], pos, transform.rotation);
                    }
                }
            }
        }
    }
}

namespace AngstyTeen.GameDirectory
{
    public class GameDirectory : MonoBehaviour
    {
        public static string GetAppDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static string GetLevelJSONFile(int saveNum)
        {
            return GetAppDataFolder() + $"\\{JSON.JSON.GamePath}\\level{saveNum.ToString()}.json";
        }
    }
}