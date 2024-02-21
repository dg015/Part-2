using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    public Vector2 kickoffPosition = Vector2.zero;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void goal()
    {
        Controller.score++;
        transform.position = kickoffPosition;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        goal();
        rb.velocity = Vector2.zero;
        Debug.Log("hit");
        ScoreText.text = "Score: " + Controller.score;
    }

}
