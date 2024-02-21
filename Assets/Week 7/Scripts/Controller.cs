using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    public float charge;
    public float maxCharge;
    public Vector2 direction;
    public static PlayerSoccer selected { get; private set; }
    public static void SetCurrentSelection(PlayerSoccer player)
    {
        if( selected != null)
        {
            selected.PlayerSelected(false);
        }
        selected = player;
        selected.PlayerSelected(true);
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero) 
        {
            selected.move(direction);
            direction = Vector2.zero;
        }
    }



    private void Update()
    {
        if (selected == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selected.transform.position).normalized * charge;

        }
    }

}
