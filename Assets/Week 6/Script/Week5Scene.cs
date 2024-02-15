using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Week5Scene : MonoBehaviour
{
    public void LoadWeek5Scene()
    {

        SceneManager.LoadScene(2);

    }

    public void Ratio()
    {
        Debug.Log("yooooo");
        Screen.SetResolution(1280,720,false);
    }

    public void FullHD()
    {
        Debug.Log("yooooo");
        Screen.SetResolution(1920, 1080, false);
    }
}
