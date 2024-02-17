using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PointClickMover : MonoBehaviour
{
    private Vector3 Coordinates;
    private Vector3 GoTo;
    [SerializeField] public int health = 5;
    public bool dead = false;
    private Vector2 CurrentSpeed;
    private Vector3 LastPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPos;
    float timer = 0 ;

    public AnimationCurve curve;

    [SerializeField] private Rigidbody2D rb;
    public Slider slider;
    public Vector2 dir;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //set slier max value to health
        slider.maxValue = health;
    }

    public void BarHealth()
    {
        //set slider value to health
        slider.value = health;
    }



    private void takeDamage(int damage)
    {
        // player takes damage and deducts damage value
        health -= damage;


    }


    private void death()
    {

        //check if player has 0 health
        if (health <= 0)
        {
            // if so make dead boolean variable true
            // change scene to death screen
            dead = true;
            Debug.Log("death");
            SceneManager.LoadScene("Death Screen");

        }


    }

    private void CurveAnimation()
    {
        // start timer
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            //when timer reaches 0 reset timer
            timer = 0;
        }

        if (CurrentSpeed.magnitude > 0.5)// check is the speed is more then 0.5 to see if player is trully walking or sliding because of lerp
        {
            //set a new scale to swap between 
            Vector2 newScale = new Vector2(1.15f, 1.15f);
            Vector2 normalScale = new Vector2(1f, 1f);
            //evalueate the curve using the previous timer
            float value = curve.Evaluate(timer);
            //lerp local scale between the two values to give impression of jumping
            transform.localScale = Vector2.Lerp(newScale, normalScale, value);
            
        }
        else
        {
            // if not set local scale to deafault one
            transform.localScale = new Vector2(1f, 1f);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        shooting();
        death();
        CurveAnimation();

        //move character trough lerp
        transform.position = Vector3.Lerp(transform.position, GoTo, Time.deltaTime * 2);
        // get direction of player 
        dir = (transform.position - GoTo).normalized;


        // find player current speed 
        CurrentSpeed = (transform.position - LastPosition) / Time.deltaTime;
        //set animations based on speed and direction
        animator.SetFloat("speed", CurrentSpeed.magnitude);
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);

        BarHealth();
        // check if dead 
        if (dead == false)
        {
            //get mouse input
            if (Input.GetMouseButton(0))
            {
                //set location for the character to go as the same where the mouse clicked
                GoTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //set z 0 so the player doesnt travel trough layers
                GoTo.z = 0;
                

            }
        }
        LastPosition = transform.position;
    }

    private void shooting()
    {
        // get inputs
        if(Input.GetKeyDown(KeyCode.W))
        {
            // instatiate the bullet with the rotation based on the key they pressed
            //up
            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0, 0));


        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            // instatiate the bullet with the rotation based on the key they pressed
            //left

            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0, 90));

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            // instatiate the bullet with the rotation based on the key they pressed
            //down
            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0, 180));

        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            // instatiate the bullet with the rotation based on the key they pressed
            //right
            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0,270));

        }
    }
}
