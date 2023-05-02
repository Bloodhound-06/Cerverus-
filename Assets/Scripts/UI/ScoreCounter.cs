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
        Score = 0;
    }

    private void Update()
    {
        text.text = Score.ToString();
    }

    public void ScoreIncrease(float increase)
    {
        Score += increase;
    }
}
