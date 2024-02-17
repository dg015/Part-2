using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SceneChangerPointClick : MonoBehaviour
{


   public void ChangeScene()
    {
        //change scene to gameplay
        SceneManager.LoadScene("Assignment");
    }
}
