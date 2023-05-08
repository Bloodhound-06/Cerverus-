using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float Score;
    public float highScore;


    private void Start()
    {
        Score = 0; //sets score to 0
    }

    private void Update()
    {
        text.text = Score.ToString(); // sets the text to the score amount
        
        PlayerPrefs.SetFloat("LatestScore", Score);
        
        if (PlayerPrefs.GetFloat("LatestScore") >= PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", Score);
        }

        if (Score == 69 && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("EasterEgg1");
        }
    }

    public void ScoreIncrease(float increase)
    {
        Score += increase; //increases core by increase
    }

    public void ScoreDied()
    {
        if (Score >= highScore)
        {
            highScore = Score;
        }
    }
}
