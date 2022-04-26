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

    Vector2 inputVector; //needed for detecting WASD keys

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject[] MenuButtons = new GameObject[3];
    // Start is called before the first frame update

    //Reference to StartPrompt
    [SerializeField] private GameObject EnterPrompt;
    [SerializeField] private GameObject MenuButtonParent;

    private void Awake()
    {
        controls = new Controls();
        menu = controls.Menus;

        InputSystem.DisableDevice(Mouse.current);
        InputSystem.EnableDevice(Mouse.current);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //MENU//
        menu.StartGame.performed += _ => OpenMenu();
        //menu.SwitchPage.performed += _ => titleScreen.SwitchInputPage();
        menu.Navigate.performed += ctx => inputVector = ctx.ReadValue<Vector2>();
        menu.CloseMenu.performed += _ => CloseSettings();

        settingsPanel.SetActive(false);
        MenuButtonParent.SetActive(false);
        EnterPrompt.SetActive(true);
        //menu.Pause.performed += _ => uiScript.PauseGame();
        //menu.SwitchPage.performed += ctx => uiScript.SwitchInputPage();

    }
    void Start()
    {


    }

    //Loads TestScene from Title
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //Pops up after pressing Enter key
    public void OpenMenu()
    {
        MenuButtonParent.SetActive(true);
        EnterPrompt.SetActive(false);
        EventSystem.current.SetSelectedGameObject(MenuButtonParent.transform.GetChild(0).gameObject);
    }

    //Opens up a Settings Menu
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Debug.Log(settingsPanel.transform.GetChild(1).gameObject);
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
