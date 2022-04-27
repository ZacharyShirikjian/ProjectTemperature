using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatforms : MonoBehaviour
{
    //Reference to FallPlatforms GObject
    private FrozenWater frozenWater;
    // Start is called before the first frame update
    void Start()
    {
        frozenWater = GetComponentInChildren<FrozenWater>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("NOW CAN FALL");
            frozenWater.GetComponentInChildren<FrozenWater>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("CAN'T FALL YET");
            frozenWater.GetComponentInChildren<FrozenWater>().enabled = false;
        }
    }
}
