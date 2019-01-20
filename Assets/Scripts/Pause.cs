using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject gameOverPanel;

    void Update()
    {
        if (Figure.gameOver == true)                                        // Show "game over" panel
        {
            gameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Figure.gameOver != true)    // If game not over
        {
            if (pausePanel.activeSelf == false)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void NewGame()
    {
        Figure.gameOver = false;

        gameOverPanel.SetActive(false);

        Field.score = 0;

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);            
    }
}
