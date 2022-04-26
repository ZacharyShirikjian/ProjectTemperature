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

    CharacterController controller;
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sprite = GetComponent<SpriteRenderer>();
        speed = 5f;
        canMove = true;
        lastDir = true;
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController>();
    }


    public void ReceiveInput(Vector2 groundMovement)
    {
        inputVector = groundMovement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb2d.MovePosition(rb2d.position + inputVector * speed * Time.fixedDeltaTime);
        controller.Move(transform.right * inputVector * speed * Time.deltaTime);
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
        //else if(inputVector == 0.0)
        //{
        //    sprite.flipX = lastDir;
        //}
    }
    public void SwitchTemperature()
    {
        Debug.Log("SWITCHING TEMPERATURE!!!");
        if(gm.curTemp <= 30.0)
        {
            Debug.Log("PLAYER IS NOW HOT");
            sprite.sprite = hotSprite;
            gm.curTemp = 60.0;
        }
        else if(gm.curTemp > 30)
        {
            Debug.Log("PLAYER IS NOW COLD");
            sprite.sprite = coldSprite;
            gm.curTemp = 30.0f;
        }
    }
}
