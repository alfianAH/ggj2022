using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;

    public int ScoreValue 
    { 
        get 
        { 
            return score; 
        } 
        set 
        { 
            score = value;
            scoreText.text = score.ToString();
        } 
    }
}
