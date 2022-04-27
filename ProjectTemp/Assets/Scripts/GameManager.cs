using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    //REFERENCES//

    //Pause Panel//
    [SerializeField] private GameObject pausePanel;
    //Reference to Player//
    [SerializeField] private GameObject player;
    private PlayerController playControl;
    [SerializeField] private Image Thermometer;
    [SerializeField] private Sprite coldTemp;
    [SerializeField] private Sprite hotTemp;
    public TextMeshProUGUI DegreeText;
    //VARIABLES//

    //Checks if game's paused
    public bool paused = false;

    public double curTemp = 32.0f;

    //AUDIO//
    private SFXManager sfx;
    private MusicManager musicManager;

    //Reference to EventSystem//
    [SerializeField] private GameObject cursor;

    public EventSystem eventSystem;

    public GameObject curButton;
    // Start is called before the first frame update
    void Start()
    {
        playControl = player.GetComponent<PlayerController>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        InputSystem.DisableDevice(Mouse.current);
        InputSystem.EnableDevice(Mouse.current);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cursor.SetActive(false);
        paused = false;
        pausePanel.SetActive(false);
        DegreeText.SetText(curTemp.ToString() + "�");
        Thermometer.sprite = coldTemp;

        if (SceneManager.GetActiveScene().name == "_TutorialLevel")
        {
            musicManager.SwitchSong("Tutorial");
        }

        else if (SceneManager.GetActiveScene().name == "_Gameplay")
        {
            musicManager.SwitchSong("Gameplay");
        }

    }

    // Update is called once per frame
    void Update()
    {
        DegreeText.SetText(curTemp.ToString() + "�F");
    }

    public void SwitchTempSprite()
    {
        if(curTemp <= 32.0)
        {
            Thermometer.sprite = coldTemp;
            sfx.GetComponent<AudioSource>().PlayOneShot(sfx.switchIce);
        }
        else if(curTemp >= 90.0)
        {
            Thermometer.sprite = hotTemp;
            sfx.GetComponent<AudioSource>().PlayOneShot(sfx.switchFire);
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
            cursor.SetActive(false);
            playControl.canMove = true;
            playControl.canSwitch = true;
        }

        else if(!paused)
        {
            pausePanel.SetActive(true);
            paused = true;
            playControl.canMove = false;
            cursor.SetActive(true);
            eventSystem.SetSelectedGameObject(curButton);
            playControl.canSwitch = false;
            Debug.Log(eventSystem.currentSelectedGameObject);

        }
    }

    //GETS CALLED WHEN PLAYER REACHES EXIT DOOR//
    public void LevelComplete()
    {
        Invoke("LoadScene", 0.5f);
        sfx.GetComponent<AudioSource>().PlayOneShot(sfx.levelComplete);
    }


    //Called from QUIT on PauseMenu
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        if (SceneManager.GetActiveScene().name == "_TutorialLevel")
        {
            SceneManager.LoadScene(1);

        }

        else if (SceneManager.GetActiveScene().name == "_Gameplay")
        {
            SceneManager.LoadScene(2);
        }
    }
    void LoadScene()
    {
        if (SceneManager.GetActiveScene().name == "_TutorialLevel")
        {
            SceneManager.LoadScene(2);

        }

        else if (SceneManager.GetActiveScene().name == "_Gameplay")
        {
            SceneManager.LoadScene(3);
        }
    }
}
