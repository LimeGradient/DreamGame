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

    public struct PlayerPosition
    {
        public float xPos { get; set; }
        public float yPos { get; set; }
        public float zPos { get; set; }
    }

    public class JSON : MonoBehaviour
    {
        private GameObject objManager;
        private Lime_Objects lo;
        public static string GamePath = "GameTest";

        private void Start()
        {
            objManager = GameObject.FindGameObjectWithTag("ObjectManager");
            lo = objManager.GetComponent<Lime_Objects>();
        }

        // this shit only for the actual scene not player
        public void CreateLevelSave(int saveNum)
        {
            if (OS.OS.IsUnix())
            {
                Directory.CreateDirectory($"{GameDirectory.GameDirectory.GetAppDataFolder()}/{GamePath}");
                File.Create(GameDirectory.GameDirectory.GetAppDataFolder() + $"/{GamePath}/level" + saveNum.ToString() +
                            ".json");
                return;
            }
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
                StreamWriter sw = File.AppendText(saveFilePath);
                sw.WriteLine(jsonToWrite);
                sw.Close();
            }
        }

        private UnityEngine.Object LoadPrefab(string name)
        {
            var loadedObject = Resources.Load(name);
            if (loadedObject == null)
            {
                throw new FileNotFoundException("...no file found");
            }

            return loadedObject;
        }

        void LoadObjectFromJSON(JSONObjectTemplate jsonTemplate, string prefabName)
        {
            Vector3 pos;
            pos.x = jsonTemplate.xPos;
            pos.y = jsonTemplate.yPos;
            pos.z = jsonTemplate.zPos;
            var loadedObj = LoadPrefab(prefabName);
            Instantiate(loadedObj, pos, Quaternion.identity);
        }
        
        public void LoadLevel(int saveNum)
        {
            foreach (string line in File.ReadLines($@"{GameDirectory.GameDirectory.GetLevelJSONFile(saveNum)}"))
            {
                JSONObjectTemplate jsonTemplate = JsonConvert.DeserializeObject<JSONObjectTemplate>(line);
                if (jsonTemplate.name.Contains("FarmPlot"))
                {
                    if (jsonTemplate.name.Contains("Lettuce"))
                    {
                        LoadObjectFromJSON(jsonTemplate, "FarmPlot_Lettuce");
                    }

                    if (jsonTemplate.name.Contains("Tomato"))
                    {
                        LoadObjectFromJSON(jsonTemplate, "FarmPlot_Tomatoes");
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
            if (OS.OS.IsUnix())
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static string GetLevelJSONFile(int saveNum)
        {
            if (OS.OS.IsUnix())
            {
                return GetAppDataFolder() + $"/{JSON.JSON.GamePath}/level{saveNum.ToString()}.json";
            }
            return GetAppDataFolder() + $"\\{JSON.JSON.GamePath}\\level{saveNum.ToString()}.json";
        }
    }
}

namespace AngstyTeen.OS
{
    public class OS
    {
        public static bool IsUnix()
        {
            var platform = (int)System.Environment.OSVersion.Platform;
            return (platform == 4) || (platform == 6) || (platform == 128);
        }
    }
}