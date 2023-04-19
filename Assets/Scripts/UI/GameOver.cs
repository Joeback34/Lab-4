using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public Canvas restartCanvas;
    public Text scoreText;
    public void PlayerDied()
    {
        player.SetActive(false);
        restartCanvas.enabled = true;
        scoreText.text = "Score:" + ScoreManager.score.ToString(); 
    }

   
}
