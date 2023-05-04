using UnityEngine;
using TMPro;
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
