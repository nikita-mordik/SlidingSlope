using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_HUD : MonoBehaviour
{
    static Game_HUD _instance;
    public static Game_HUD Instance { get => _instance; set => _instance = value; }

    public Text[] scores;
    public Text maxScore;
    public Text MaxScore { get => maxScore; set => maxScore = value; }
    private Save save = new Save();

    public GameObject loseWindow;

    public Text bestScoretext;
    public Text shareText;
    public Text menuText;
    public Text restartText;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        Time.timeScale = 1.0f;

        //if (LanguageSystem.m_Instance.indexLang == 0)
        //{
        //    bestScoretext.text = LanguageSystem.Lang.bestScore;
        //    shareText.text = LanguageSystem.Lang.share;
        //    menuText.text = LanguageSystem.Lang.mainMenu;
        //    restartText.text = LanguageSystem.Lang.restart;
        //}
        //else if (LanguageSystem.m_Instance.indexLang == 1)
        //{
        //    bestScoretext.text = LanguageSystem.Lang.bestScore;
        //    shareText.text = LanguageSystem.Lang.share;
        //    menuText.text = LanguageSystem.Lang.mainMenu;
        //    restartText.text = LanguageSystem.Lang.restart;
        //}
    }

    private void Start()
    {
        //maxScore.text = save.maxScore.ToString();
    }

    private void Update()
    {
        UpdateScore(GameController.Instance.Score);

        GameOver(GameController.IsLose);
    }

    void UpdateScore(int score)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].text = score.ToString();
        }
    }

    void GameOver(bool isLose)
    {
        if (isLose)
        {
            loseWindow.SetActive(isLose);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartLevel()
    {
        GameController.IsLose = false;
        loseWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        GameController.IsLose = false;
        loseWindow.SetActive(false);
        SceneManager.LoadScene(0);
    }
}