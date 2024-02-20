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
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //find player transform and score script
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
        //walk directly to player
        direction = player.position - transform.position; // find direction between player and enemy ( distance as well)
        faceRotation = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg; // get the angle from the enemy to player and apply as degrees
        transform.rotation = Quaternion.Euler(0f, 0f, faceRotation); // apply angle as rotation
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);// make enemy walk towards player based on speed
    }


    public void takeDamageEnemy(int damage)
    { 
        //Enemy take damage function
        health -= damage;
        Debug.Log("enemy damage");
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //enemy deal damage to palyer upon colision 
        collision.SendMessage("takeDamage", 1,SendMessageOptions.DontRequireReceiver );
        Debug.Log("damage");

    }

    private void die()
    {
        // if health is 0 remove enemy object and add 1 point
        if ( health <= 0)
        {
            Score.addScore(1);
            Destroy(this.gameObject);
            Debug.Log("ded");
        }
    }

}
