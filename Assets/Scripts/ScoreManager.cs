using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    //[HideInInspector]
    public int currentScore;
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

    private void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreLevel (TMP)").GetComponent<TextMeshProUGUI>();
        }
    }

    public void AddScore()
    {
        currentScore += 1;
        scoreText.text = "Score : " + currentScore.ToString();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreLevel (TMP)").GetComponent<TextMeshProUGUI>();
        }
        scoreText.text = "Score : " + currentScore.ToString();
    }

}
