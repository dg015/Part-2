using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    [SerializeField] private float speed = 3;
    [SerializeField] private Animator animator;
    [SerializeField] private bool clickingSelf = false;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private bool dead= false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        if (dead) return;
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
        
            movement = Vector2.zero;    
        
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        if (Input.GetMouseButtonDown(0) && !clickingSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("movement", movement.magnitude);
    }
    private void OnMouseDown()
    {
        if (dead) return;
        clickingSelf = true;
        damage(1);
    }
    private void OnMouseUp()
    {
        clickingSelf = false;
    }
    private void damage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            animator.SetTrigger("Death");
            dead = true;
        }
        else
        {
            dead = false;
            animator.SetTrigger("Hurt");
        }
    }
}
