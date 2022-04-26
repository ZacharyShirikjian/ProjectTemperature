using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    //VARIABLES//
    [SerializeField] public static int musicVolume = 100;
    //[SerializeField] public static int volume = 100; 

    public static void ChangeMusicVol(int value)
    {
        musicVolume = value;
    }
}
