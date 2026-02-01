using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public AudioSource gameOverSound;

    public void restartGame()
    {
        // Called when the player presses "Play Again" on the game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } // end of restartGame method

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverSound.Play();
    } // end of gameOver method

} // end of LogicScript class
