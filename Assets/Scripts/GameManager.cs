using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int MENU_SCENE = 0;
    public const int BREAKOUT_GAME_SCENE = 1;

    public static GameManager Instance;

    public string currentName;
    public SaveData saveData;

    private string saveFilePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        saveFilePath = Application.persistentDataPath + "/save.json";

        LoadHighScore();
    }

    public void SaveHighScore(int score)
    {
        SaveData saveData = new SaveData();
        saveData.hiScoreName = currentName;
        saveData.highestScore = score;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(saveFilePath, json);
    }

    public void LoadHighScore()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string hiScoreName;
        public int highestScore;
    }
}
