using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text bestScoreText;
    public TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        nameInputField.text = GameManager.Instance.currentName;

        if (GameManager.Instance.saveData.highestScore > 0)
        {
            string hiScoreName = GameManager.Instance.saveData.hiScoreName;
            int highestScore = GameManager.Instance.saveData.highestScore;

            bestScoreText.text = $"Best Score: {hiScoreName} : {highestScore}";
            bestScoreText.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        GameManager.Instance.currentName = nameInputField.text;
        SceneManager.LoadScene(GameManager.BREAKOUT_GAME_SCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
