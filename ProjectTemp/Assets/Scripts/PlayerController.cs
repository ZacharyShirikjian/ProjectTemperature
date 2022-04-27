using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //VARIABLES//
    public Vector2 inputVector;
    [SerializeField] float speed = 5f;    //speed of player movement//
    Rigidbody2D rb2d;
    public bool canMove = true;    //Checks if player can move//
    private bool lastDir; //last direction player faced in, left = false, right = true
    private Vector2 moveDirection = Vector2.zero;

    //REFERENCES//
    //Reference to PlayerSprite//
    SpriteRenderer sprite;

    [SerializeField] private Sprite hotSprite;
    [SerializeField] private Sprite coldSprite;
    private GameManager gm;

    public bool canSwitch = true; //set to false if player is gonna die
    public bool canExit = false;
    private SFXManager sfx; 
    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        speed = 5f;
        canMove = true;
        lastDir = true;
    }


    public void ReceiveInput(Vector2 groundMovement)
    {
        inputVector = groundMovement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove)
        {
            transform.position += transform.right * inputVector.x * speed * Time.deltaTime;
            //controller.Move(transform.right * inputVector * speed * Time.deltaTime);
            if (inputVector.x < 0)
            {
                sprite.flipX = true;
                lastDir = true;
            }
            else if (inputVector.x > 0)
            {
                sprite.flipX = false;
                lastDir = false;
            }

        }

        //else if(inputVector == 0.0)
        //{
        //    sprite.flipX = lastDir;
        //}
    }
    public void SwitchTemperature()
    {
        Debug.Log("SWITCHING TEMPERATURE!!!");
        if (canSwitch)
        {
            if (gm.curTemp <= 32.0)
            {
                Debug.Log("PLAYER IS NOW HOT");
                sprite.sprite = hotSprite;
                gm.curTemp = 90.0;
                gm.SwitchTempSprite();
            }
            else if (gm.curTemp > 32)
            {
                Debug.Log("PLAYER IS NOW COLD");
                sprite.sprite = coldSprite;
                gm.curTemp = 30.0f;
                gm.SwitchTempSprite();
            }
        }
    }

    //Gets called when pressing ENTER at the door when a player is near it 
    public void ExitDoor()
    {
        if(canExit)
        {
            gm.LevelComplete();
        }
    }
}
