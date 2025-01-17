using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GoalkeeperController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    //[SerializeField] private Transform goal;
    [SerializeField] private Transform goalkeeper;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float goalRadius = 1.7f;
    [SerializeField] private float step;

    // Start is called before the first frame update

    


    private void FixedUpdate()
    {
        if (Controller.selected != null)
        {
            direction = (Vector2)Controller.selected.transform.position - (Vector2)transform.position;
            float distance = direction.magnitude;
            if (goalRadius > (distance / 2f))
            {
                
                goalkeeper.position = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction.normalized * (distance / 2f), step);
            }
            else
            {

                goalkeeper.position = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction.normalized * goalRadius, step);
            }
        }
        
    }

}
