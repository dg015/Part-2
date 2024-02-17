using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class ScoreRetriever : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        // retrieve score from previous scene and set it in text
        scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "score:" + score;
    }
}
