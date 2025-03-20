using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurnState : StateMachineState
{
    private GameManager gameManager;
    private MyInputActions playerInput;
    private bool mouseWasReleased = false;

    public PlayerTurnState(GameManager manager)
    {
        gameManager = manager;
        playerInput = new MyInputActions(); 
    }

    public override void Enter()
    {
        Debug.Log("Player's turn...");
        gameManager.SetControls(true);
        playerInput.Enable(); 
        playerInput.Mouse.MouseReleased.performed += OnMouseReleased;
    }

    public override void Update()
    {
        if (mouseWasReleased)
        {
            gameManager.SetControls(false);
            gameManager.SetState(new PuckMovingState(gameManager));
        }
    }

    private void OnMouseReleased(InputAction.CallbackContext context)
    {
        mouseWasReleased = true;
    }

    public override void Exit()
    {
        playerInput.Mouse.MouseReleased.performed -= OnMouseReleased;
        playerInput.Disable();
    }
}

