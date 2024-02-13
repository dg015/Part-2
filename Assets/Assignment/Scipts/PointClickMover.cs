using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PointClickMover : MonoBehaviour
{
    [SerializeField] private Vector3 Coordinates;
    [SerializeField] private Vector3 GoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            GoTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GoTo.z = 0;
            Debug.Log("yoo");
            
        }
       

    }

    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, GoTo, Time.deltaTime * 2);

    }
}
