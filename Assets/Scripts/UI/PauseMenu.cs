using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button pauseButton;
    public Button backToMenuButton;
    public GameObject pauseButtonObj;
   

    void Start()
    {
        pauseButtonObj.SetActive(true);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
    }

    private void Update()
    {

        if (Keyboard.current[Key.Escape].isPressed)
        {
            PauseGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        pauseButtonObj.SetActive(false);
       
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        pauseButtonObj.SetActive(true);
    }
    
    void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    
}