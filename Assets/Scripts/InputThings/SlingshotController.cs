using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingshotController : MonoBehaviour
{
    public Slingshot slingshot;
    private CommandInvoker invoker = new CommandInvoker();
    private Vector3 pullPosition;
    private MyInputActions inputActions;

    private void Start()
    {
        inputActions = new MyInputActions();
        inputActions.Enable();
        inputActions.Mouse.MouseMoved.performed += OnMouseMoved;
        inputActions.Mouse.MouseMoved.performed -= OnMouseMoved;
        inputActions.Mouse.MouseReleased.performed += OnMouseReleased;
        inputActions.Mouse.MouseReleased.performed -= OnMouseReleased;
    }
    private void Update()
    {
        //Converte la posizione in coordinate di gioco;
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        pullPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
    }

    private void OnMouseReleased(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            invoker.ExecuteCommand(new ChargeCommand(slingshot, pullPosition));

        }
    }

    private void OnMouseMoved(InputAction.CallbackContext context)
    {
       if (context.performed)
       {
            invoker.ExecuteCommand(new ReleaseCommand(slingshot));
       }
    }

    
}
