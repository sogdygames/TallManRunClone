using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue;
    public static TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        score.text =  scoreValue + " ";
    }
}
