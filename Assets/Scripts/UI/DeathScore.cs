using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScore : MonoBehaviour
{
    public TextMeshProUGUI highScore, score;
    private void Update()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString();

        score.text = PlayerPrefs.GetFloat("LatestScore").ToString();
    }
}
