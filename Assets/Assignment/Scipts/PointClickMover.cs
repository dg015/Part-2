using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PointClickMover : MonoBehaviour
{
    [SerializeField] private Vector2 Coordinates;
    [SerializeField] private Vector2 GoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            
            
            while (Coordinates != Vector2.Lerp(transform.position, GoTo, Time.deltaTime))
            {
                Coordinates = Vector2.Lerp(transform.position, GoTo, Time.deltaTime);
            }
            transform.position = Coordinates;
        }
        

    }
}
