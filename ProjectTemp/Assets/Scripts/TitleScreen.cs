using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TitleScreen : MonoBehaviour
{
    Controls controls;
    Controls.MenusActions menu;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject[] MenuButtons = new GameObject[3];
    // Start is called before the first frame update

    private void Awake()
    {
        controls = new Controls();
        menu = controls.Menus;

        //MENU//
        menu.CloseMenu.performed += ctx => CloseSettings();
        //menu.Pause.performed += _ => uiScript.PauseGame();
        //menu.SwitchPage.performed += ctx => uiScript.SwitchInputPage();

    }
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads TestScene from Title
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //Opens up a Settings Menu
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settingsPanel.transform.GetChild(1).gameObject);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(MenuButtons[0]);
    }

    //Quits Game from Title
    public void QuitGame()
    {
        Application.Quit();
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
