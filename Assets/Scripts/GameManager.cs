using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    

    public static GameManager instance;
    public static int score;

    void Awake()
    {
        // Implement the singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }

     public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
