using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    //Start Position of the Crate for Respawning (respawns automatically if destroyed)
    public Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }
}
