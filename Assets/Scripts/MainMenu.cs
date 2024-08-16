using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text scoreText;
    void Start()
    {
        scoreText.text = "Score:" + GameManager.score;
    }

    public void PlayGame()
    {
        // Assuming your game scene is called "GameScene"
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
       
        Application.Quit();
    }

}
