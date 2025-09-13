using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameWonCanvas;
    public GameObject tapToStart;
    public GameObject gameName;
    public AudioClip winAudio;
    public AudioClip loseAudio;
    public AudioSource bgMusic;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        gameWonCanvas.SetActive(false);
        tapToStart.SetActive(true);
        gameName.SetActive(true);
        PauseGame();
    }

  void Update()
  {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        {
        
    }
  }
    public void GameOver()
    {
        bgMusic.Stop();
        bgMusic.PlayOneShot(loseAudio);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameWon()
    {
        bgMusic.Stop();
        bgMusic.PlayOneShot(winAudio);
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

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        tapToStart.SetActive(false);
        gameName.SetActive(false);
    }
}
