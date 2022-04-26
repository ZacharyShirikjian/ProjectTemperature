using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{

    //Reference to Player//
    private PlayerController player;
    private BoxCollider2D collision;
    private GameManager gm;
    private BoxCollider2D collider;
    //private AudioSource sfxSource;
   // private AudioClip melt; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //sfxSource = GameObject.Find("SFXManager").GetComponent<AudioSource>();
        //IceCube.sfxSource = 
        //melt = sfx.FireSpell;
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.curTemp >= 90.0)
        {
            Debug.Log("CAN BE MELTED");
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //sfxSource.PlayClipAtPoint(melt, transform.position);
            Destroy(this.gameObject);
            player.GetComponent<PlayerController>().canSwitch = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<PlayerController>().canSwitch = true;
    }

    private void OnDestroy()
    {
        if(player != null)
        {
            player.GetComponent<PlayerController>().canSwitch = true;
        }
    }

}
