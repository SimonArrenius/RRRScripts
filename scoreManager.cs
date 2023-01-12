using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    
    public Text scoreText;
    public float pointsPerSecond;
    public float scoreAmount;

    void Start()
    {
        scoreAmount = 0f;
        pointsPerSecond = 0f;
    }

    void Update()
    {
        scoreText.text = "SCORE-" + (int)scoreAmount;
        scoreAmount += pointsPerSecond * Time.deltaTime;
    }
}
