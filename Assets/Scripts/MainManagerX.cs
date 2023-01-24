using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManagerX : MonoBehaviour
{
    public static MainManagerX Instance;

    [Header("Save Data")]
    public string PlayerName;
    public int m_highScore;

    [Header("Current Game")]
    public string m_cPlayerName;
    public int m_cScore;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
       
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int m_highScore;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.m_highScore = m_highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            m_highScore = data.m_highScore;
        }
    }
}
