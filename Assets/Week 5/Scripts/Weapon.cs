using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * Time.deltaTime);
    }
 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("takeDamage", 1);
        Destroy(this.gameObject);
    }
}
