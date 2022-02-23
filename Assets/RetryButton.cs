using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
  public void Retry()
    {
        SceneManager.LoadScene(0);
        ScoreController.score = 0;
        PlayerController.gameOver = false;
    }
}
