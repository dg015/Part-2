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
        currentTime += Time.deltaTime;
        if (currentTime >= TimerLimit)
        {
            currentTime = 0;
            spawn();
        }

    }

    private void spawn()
    {
        Instantiate(enemy);
    }



}
