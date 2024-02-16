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


    private void takeDamage(int damage)
    {
        health -= damage;


    }


    private void death()
    {
        if (health <= 0)
        {
            Debug.Log("death");
            SceneManager.LoadScene("Death Screen");

        }


    }

    private void CurveAnimation()
    {
        
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
        }

        if (CurrentSpeed.magnitude > 0.5)
        {
            Vector2 newScale = new Vector2(1.15f, 1.15f);
            Vector2 normalScale = new Vector2(1f, 1f);
            float value = curve.Evaluate(timer);
            transform.localScale = Vector2.Lerp(newScale, normalScale, value);
            
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);

        }

    }

    // Update is called once per frame
    void Update()
    {
        shooting();
        death();
        CurveAnimation();

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

    private void shooting()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0, 0));


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            //gunPos.transform.position = new Vector3(-0.376f,0 , 0);
            
            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0, 90));

        }
        if (Input.GetKeyDown(KeyCode.S))
        {


            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0, 180));

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            

            Instantiate(bullet, gunPos.position, Quaternion.Euler(0, 0,270));

        }
    }
}
