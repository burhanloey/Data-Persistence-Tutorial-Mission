using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int MENU_SCENE = 0;
    public const int BREAKOUT_GAME_SCENE = 1;

    public static GameManager Instance;

    public GameData data;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Play()
    {
        SceneManager.LoadScene(BREAKOUT_GAME_SCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }

    [SerializeField]
    public class GameData
    {
        public string currentName;
        public string highestScoreName;
        public int highestScore;
    }
}
