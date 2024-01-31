using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public AnimationCurve curve;
    private float landingTimer;
    [SerializeField] CircleCollider2D colider;
    [SerializeField] SpriteRenderer spriteRenderer;
    public bool landing = false;
    
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Detection range"))
        {
            spriteRenderer.color = Color.red;

        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Detection range"))
        {
            if (Vector3.Distance(transform.position, collision.transform.position) <= 0.5f)
            {

                Destroy(this.gameObject);

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }


    private void land()
    {
        if (landing)
        {
            speed = 0;
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = curve.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                
                Destroy(gameObject);
                
            }

            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);

        }


    }


    private void Update()
    {
        land();

        if (lineRenderer.positionCount > 0)
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
                if (lineRenderer.positionCount !=0)
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
