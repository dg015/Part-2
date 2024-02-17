using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SceneChangerPointClick : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("Score", score);
        scoreText.text = "score:" + score;

    }


   public void ChangeScene()
    {
        SceneManager.LoadScene("Assignment");
    }
}
