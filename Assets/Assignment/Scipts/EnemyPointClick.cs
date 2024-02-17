using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyPointClick : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private int health = 3;
    [SerializeField] private int deamage;
    [SerializeField] private Vector2 distance;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float faceRotation;
    [SerializeField] private ScoreManager Score;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        Score = GameObject.Find("Score manage").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        chase();
        die();
    }




    private void chase()
    {
        direction = player.position - transform.position;
        distance = player.position - transform.position;
        faceRotation = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, faceRotation);
        transform.Translate(distance * Time.deltaTime * speed);
    }


    public void takeDamageEnemy(int damage)
    { 
        health -= damage;
        Debug.Log("enemy damage");
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.SendMessage("takeDamage", 1);
        Debug.Log("damage");
    }

    private void die()
    {
        
        if ( health <= 0)
        {
            Score.addScore(1);
            Destroy(this.gameObject);
            Debug.Log("ded");
        }
    }

}
