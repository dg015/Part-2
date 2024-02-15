
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{

    [SerializeField] GameObject planePrefab;
    [SerializeField] GameObject plane;
    [SerializeField] private float time = 5;
    [SerializeField] private float positionRandom;
    [SerializeField] private float rotationRandom;
    [SerializeField] private Vector3 position;
    public int score;
    [SerializeField] private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {

        //Sprite = Random.Range(0, 4);

    }

    // Update is called once per frame
    void Update()
    {
        positionRandom = Random.Range(-5, 5);
        rotationRandom = Random.Range(0, 260);
        position = new Vector3(positionRandom, positionRandom, 0);

        
        time += Time.deltaTime;
        
        if (time >= 5)
        {
            time = 0;
            plane = Instantiate(planePrefab, position, Quaternion.Euler(0,0, rotationRandom));
            plane.GetComponent<Plane>().speed = Random.Range(1,4);
            plane.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0,4)];


        }


    }


}
