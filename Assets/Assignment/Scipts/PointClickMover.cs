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
    public Slider slider;
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

    }

    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, GoTo, Time.deltaTime * 2);

    }
}
