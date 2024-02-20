using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 15;
    [SerializeField] private float maxTimer = 5;
    private float timer;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        //move rigidbody
        rb.MovePosition(transform.up * speed* Time.deltaTime + transform.position);
    }

    private void Update()
    {
        
        autoDestruct();
    }

    private void autoDestruct()
    {
        //set a timer to autodestruct after a few seconds
        timer += Time.deltaTime;
        if( timer >= maxTimer )
        {
            
            timer = 0;
            Destroy(this.gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when colides destroy the object and sends message to colider to deduct one health point from enemy
        Destroy(this.gameObject);
        collision.SendMessage("takeDamageEnemy", 1, SendMessageOptions.DontRequireReceiver);
        Debug.Log("damage to enemy");

    }


}
