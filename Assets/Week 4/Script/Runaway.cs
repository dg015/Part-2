using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runaway : MonoBehaviour
{
    public int score;
    [SerializeField] BoxCollider2D boxCollider;

 

    private void OnTriggerStay2D(Collider2D other)
    {
       
        if (boxCollider.OverlapPoint(other.transform.position))
        {
            if (!other.GetComponent<Plane>().landing)
            {
                other.GetComponent<Plane>().speed = 0;
                other.GetComponent<Plane>().landing = true;
                score++;
                Debug.Log(score);
            }
        }

    }

}
