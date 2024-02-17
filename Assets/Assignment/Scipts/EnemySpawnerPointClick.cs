using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPointClick : MonoBehaviour
{
    [SerializeField] private float currentTime;
    [SerializeField] private float TimerLimit;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //after timer reaches 0 spawn enemy 
        currentTime += Time.deltaTime;
        if (currentTime >= TimerLimit)
        {
            currentTime = 0;
            spawn();
        }

    }

    private void spawn()
    {
        //spawn enemy on spawner position
        Instantiate(enemy,transform.position, Quaternion.Euler(0, 0, 0));
    }



}
