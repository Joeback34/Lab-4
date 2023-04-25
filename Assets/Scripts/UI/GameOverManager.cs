using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public Button backToMenu;
    public Button restartButton;
    public GameObject gameOverUI;

    private void Start()
    {
        backToMenu.onClick.AddListener(BackToMenu);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.score = 0;
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}