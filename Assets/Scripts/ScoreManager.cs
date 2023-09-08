using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [HideInInspector] public int currentScore;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore()
    {
        currentScore += 1;
        scoreText.text = "Score : " + currentScore.ToString();
    }

}
