using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float Score;


    private void Start()
    {
        Score = 0; //sets score to 0
    }

    private void Update()
    {
        text.text = Score.ToString(); // sets the text to the score amount
    }

    public void ScoreIncrease(float increase)
    {
        Score += increase; //increases core by increase
    }
}
