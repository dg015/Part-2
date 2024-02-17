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
        scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
    }

    public void addScore(int value)
    {
        score += value;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score:" + score;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();    
    }
}
