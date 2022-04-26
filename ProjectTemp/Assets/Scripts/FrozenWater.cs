using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenWater : MonoBehaviour
{
    //Reference to Player//
    private PlayerController player;
    private BoxCollider2D collision;
    private GameManager gm;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    [SerializeField] private Sprite coldSprite;
    [SerializeField] private Sprite hotSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.curTemp <= 32.0)
        {
            Debug.Log("FROZEN WATER");
            collider.isTrigger = false;
            sprite.sprite = coldSprite;
        }
        else if(gm.curTemp >= 60.0)
        {
            Debug.Log("MELTED WATER");
            collider.isTrigger = true;
            sprite.sprite = hotSprite;
        }
    }
}
