using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Controls controls;
    Controls.PlayerActions player;
    private void Awake()
    {
        controls.Player.Shoot.performed += _ => Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("ttttttt");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
