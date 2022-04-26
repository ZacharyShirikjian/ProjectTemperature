using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    //REFERENCES//

    //Pause Panel//
    [SerializeField] private GameObject pausePanel;

    //Reference to Player//
    [SerializeField] private GameObject player;

    //VARIABLES//

    //Checks if game's paused
    public bool paused = false;

    public double curTemp = 30.0f; 
    // Start is called before the first frame update
    void Start()
    {
        InputSystem.DisableDevice(Mouse.current);
        InputSystem.EnableDevice(Mouse.current);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        paused = false;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Closes a menu//
    public void CloseMenu()
    {
        //if(pausePanel.activeSelf == true)
        //{
        //    paused = false;
        //    pausePanel.SetActive(false);
        //}
    }

    public void PauseGame()
    {
        if(paused)
        {
            pausePanel.SetActive(false);
            paused = false;
        }

        else if(!paused)
        {
            pausePanel.SetActive(true);
            paused = true;
        }
    }
}
