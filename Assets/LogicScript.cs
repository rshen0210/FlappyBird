using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject beginScreen;
    [ContextMenu("Increase Score")]
    void Start() {
        pauseGame();
    }
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void gameOver() {
        gameOverScreen.SetActive(true);
        StartCoroutine(pauseAfterDelay(3));
    }
    private IEnumerator pauseAfterDelay(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 0;
    }
    public void pauseGame() {
        Time.timeScale = 0;
        beginScreen.SetActive(true);
    }
    public void unpauseGame() {
        Time.timeScale = 1;
        beginScreen.SetActive(false);
    }
}
