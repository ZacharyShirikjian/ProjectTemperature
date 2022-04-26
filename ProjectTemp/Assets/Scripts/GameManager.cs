using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

    //AUDIO//
    private SFXManager sfx;
    private MusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        InputSystem.DisableDevice(Mouse.current);
        InputSystem.EnableDevice(Mouse.current);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        paused = false;
        pausePanel.SetActive(false);
        DegreeText.SetText(curTemp.ToString() + "°");
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
        DegreeText.SetText(curTemp.ToString() + "°F");
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
        }

        else if(!paused)
        {
            pausePanel.SetActive(true);
            paused = true;
        }
    }

    //GETS CALLED WHEN PLAYER REACHES EXIT DOOR//
    public void LevelComplete()
    {
        Invoke("LoadSceneAfterDelay", 0.5f);
        sfx.GetComponent<AudioSource>().PlayOneShot(sfx.levelComplete);
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
