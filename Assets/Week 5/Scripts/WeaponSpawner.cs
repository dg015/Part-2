using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weapon;

    public void SpawnWeapon()
    {
        Instantiate(weapon);


    }

 
}
