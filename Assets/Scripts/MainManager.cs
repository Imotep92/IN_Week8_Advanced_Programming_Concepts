using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color unitColour;

    private void Awake()
    {
        // Making sure that there is always one copy of this (destroying any copies)
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        // Setting the current object as Instance
        Instance = this;

        // Making this object persistent
        DontDestroyOnLoad(gameObject);

        // Load colour if one is saved 
        loadColour();
    }
   
    [System.Serializable]
    class saveData
    {
        public Color _unitColour;
    }

    public void saveColour()
    {
        saveData data = new saveData();
        data._unitColour = unitColour;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void loadColour()
    {
        string path = Application.persistentDataPath + "/svaefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData data = JsonUtility.FromJson<saveData>(json);
            unitColour = data._unitColour;
        }
    }
}
