using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class PointClickMover : MonoBehaviour
{
    [SerializeField] private Vector3 Coordinates;
    [SerializeField] private Vector3 GoTo;
    [SerializeField] public int health = 5;
    [SerializeField] public bool dead = false;
    [SerializeField] private Vector2 CurrentSpeed;
    [SerializeField] private Vector3 LastPosition;

    [SerializeField] private Rigidbody2D rb;
    public Slider slider;
    public Vector2 dir;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
    }

    public void BarHealth()
    {
        
        slider.value = health;
    }

    private void die()
    {
        if (health <= 0)
        { 
            dead = true;    
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GoTo, Time.deltaTime * 2);
        dir = (transform.position - GoTo).normalized;
        

        CurrentSpeed = (transform.position - LastPosition) / Time.deltaTime;
        animator.SetFloat("speed", CurrentSpeed.magnitude);
        animator.SetFloat("Horizontal", dir.x);

        animator.SetFloat("Vertical", dir.y);
        die();
        BarHealth();
        if (dead == false)
        {
            if (Input.GetMouseButton(0))
            {
                GoTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GoTo.z = 0;
                Debug.Log("yoo");

            }
        }
        LastPosition = transform.position;
    }

    private void FixedUpdate()
    {



    }
}
