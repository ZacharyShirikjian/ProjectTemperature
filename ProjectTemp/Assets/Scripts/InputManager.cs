using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controls controls;
    Controls.MenusActions menu;
    Controls.PlayerActions playerActions;

    Vector2 mousePos;

    Vector2 inputVector;
    Vector2 mouseInput;

    [SerializeField] private GameManager gm;
    [SerializeField] private PlayerController playCon;
    private void Start()
    {
       playCon = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Awake()
    {
        controls = new Controls();
        menu = controls.Menus;
        playerActions = controls.Player;

        //PLAYER//
        playerActions.Move.performed += ctx => inputVector = ctx.ReadValue<Vector2>();
        playerActions.SwitchTemp.performed += _ => playCon.SwitchTemperature();

        //MENU//
        menu.CloseMenu.performed += ctx => gm.CloseMenu();
        menu.Pause.performed += _ => gm.PauseGame();
        //movement.Interact.performed += ctx => playInteract.Interact();
        //menu.SwitchPage.performed += ctx => uiScript.SwitchInputPage();

    }

    private void FixedUpdate()
    {
        //mousePos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        //playCon.ReceiveInput(inputVector);
        float horizontal = playerActions.Move.ReadValue<Vector2>().x;
        Vector2 move = new Vector2(horizontal, 0);
        playCon.ReceiveInput(move);
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
