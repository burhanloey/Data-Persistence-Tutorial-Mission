using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int MenuSceneIndex = 0;
    public const int BreakoutGameSceneIndex = 1;

    public static GameManager Instance;

    public string CurrentName;
    public SaveData Data;

    private string m_SaveFilePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        m_SaveFilePath = Application.persistentDataPath + "/save.json";

        LoadHighScore();
    }

    public void SaveHighScore(int score)
    {
        SaveData data = new SaveData();
        data.HiScoreName = CurrentName;
        data.HighestScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(m_SaveFilePath, json);
    }

    public void LoadHighScore()
    {
        if (File.Exists(m_SaveFilePath))
        {
            string json = File.ReadAllText(m_SaveFilePath);
            Data = JsonUtility.FromJson<SaveData>(json);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string HiScoreName;
        public int HighestScore;
    }
}
