using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointClick : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int deamage;
    [SerializeField] private Vector2 distance;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float faceRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chase();
        
    }


    private void chase()
    {
        direction = player.position - transform.position;
        distance = player.position - transform.position;
        faceRotation = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, faceRotation);
        transform.Translate(distance * Time.deltaTime * speed);



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.SendMessage("takeDamage", 1);
        Debug.Log("damage");
    }
    

}
