using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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

}
