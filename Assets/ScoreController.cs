using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public TMP_Text txtScore;
    public static float score;
    public float pointsPerSecond = 1;

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.gameOver)
        {
            score += pointsPerSecond * Time.deltaTime;
            var newScore = Mathf.Round(score);
            txtScore.text = "score : " + newScore.ToString();
        }
     
       
    }
}
