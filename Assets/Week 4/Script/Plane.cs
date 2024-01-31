using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points;
    Vector3 lastPosition;
    public float pointThreshold = 0.2f;
    public LineRenderer lineRenderer;
    Vector2 curretPosition;
    [SerializeField] Rigidbody2D rb;
    public float speed = 1;



     void Start()
    {
            
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        curretPosition = transform.position;
        if (points .Count > 0)
        {
            Vector2 direction = points[0] - curretPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;

        }
        rb.MovePosition(rb.position + (Vector2)transform.up  * speed * Time.deltaTime );

    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {

            if (Vector2.Distance(curretPosition, points[0]) < pointThreshold)
            {
                points.RemoveAt(0);

                for ( int i = 0; i< lineRenderer.positionCount -2; i++ )
                {
                    lineRenderer.SetPosition( i,lineRenderer.GetPosition(i+1) );

                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

    }

    private void OnMouseDrag()
    {

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > pointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;


        }
    

    }


}
