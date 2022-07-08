using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public TMP_InputField NameInputField;

    // Start is called before the first frame update
    void Start()
    {
        NameInputField.text = GameManager.Instance.CurrentName;

        if (GameManager.Instance.Data.HighestScore > 0)
        {
            string hiScoreName = GameManager.Instance.Data.HiScoreName;
            int highestScore = GameManager.Instance.Data.HighestScore;

            BestScoreText.text = $"Best Score: {hiScoreName} : {highestScore}";
            BestScoreText.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        GameManager.Instance.CurrentName = NameInputField.text;
        SceneManager.LoadScene(GameManager.BreakoutGameSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
