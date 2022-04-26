using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //REFERENCES//

    //Pause Panel//
    [SerializeField] private GameObject pausePanel;
    //Reference to Player//
    [SerializeField] private GameObject player;
    [SerializeField] private Image Thermometer;
    [SerializeField] private Sprite coldTemp;
    [SerializeField] private Sprite hotTemp;
    public TextMeshProUGUI DegreeText;
    //VARIABLES//

    //Checks if game's paused
    public bool paused = false;

    public double curTemp = 32.0f; 
    // Start is called before the first frame update
    void Start()
    {
        InputSystem.DisableDevice(Mouse.current);
        InputSystem.EnableDevice(Mouse.current);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        paused = false;
        pausePanel.SetActive(false);
        DegreeText.SetText(curTemp.ToString() + "°");
        Thermometer.sprite = coldTemp;
    }

    // Update is called once per frame
    void Update()
    {
        DegreeText.SetText(curTemp.ToString() + "°F");
    }

    public void SwitchTempSprite()
    {
        if(curTemp <= 32.0)
        {
            Thermometer.sprite = coldTemp;
        }
        else if(curTemp >= 90.0)
        {
            Thermometer.sprite = hotTemp;
        }
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
