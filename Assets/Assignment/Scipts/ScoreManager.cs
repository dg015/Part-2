using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        //find score text
        scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
    }

    public void addScore(int value)
    {
        //add score to score variable
        score += value;
    }

    // Update is called once per frame
    void Update()
    {
        //set score text to have the score number
        scoreText.text = "score:" + score;
    }

    private void OnDestroy()
    {
        // set score on PlayerPrefs to travel across scenes
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();    
    }
}
