using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerSoccer : MonoBehaviour
{

    [SerializeField] private Color col;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = spriteRenderer.color;
        
    }


    public void PlayerSelected(bool selected)
    {

       if (selected)
       {
            spriteRenderer.color = Color.white;
       }
       else
       {
            spriteRenderer.color = col; 
       }
    }

    /*
     (private void OnMouseUp()
    {
        PlayerSelected(false);
    }
    */
    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
        //PlayerSelected(true);
    }

    public void move(Vector2 direction)
    {
        
        rb.AddForce(direction * speed, ForceMode2D.Impulse );
    }
}
