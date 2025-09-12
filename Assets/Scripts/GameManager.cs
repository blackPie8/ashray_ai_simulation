using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameWonCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        gameWonCanvas.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void GameWon()
    {
        Time.timeScale = 0f;
        gameWonCanvas.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
