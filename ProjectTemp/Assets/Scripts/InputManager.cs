using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controls controls;
    Controls.MenusActions menu;
  //  private PlayerController playCon;

    Vector2 mousePos;

    Vector2 inputVector;
    Vector2 mouseInput;

    [SerializeField] private TitleScreen titleScript;
    private void Start()
    {
       // playCon = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Awake()
    {
        controls = new Controls();
        menu = controls.Menus;

        //movement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        //movement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        //MENU//
        menu.CloseMenu.performed += ctx => titleScript.CloseSettings();
        //menu.Pause.performed += _ => uiScript.PauseGame();
        //movement.Interact.performed += ctx => playInteract.Interact();
        //menu.SwitchPage.performed += ctx => uiScript.SwitchInputPage();

    }

    private void Update()
    {
        //mousePos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());

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
