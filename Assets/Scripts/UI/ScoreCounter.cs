using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float count = 0;
    private void Start()
    {
        text.text = count.ToString();
    }

    public void IncreaseScore(float increase)
    {
        count += increase;
        text.text = count.ToString();a
    }
}
