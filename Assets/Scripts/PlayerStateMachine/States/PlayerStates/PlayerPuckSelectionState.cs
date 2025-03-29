using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPuckSelectionState : GenericState
{
    public MyInputActions inputAction;
    private PlayerStateMachine stateMachine;
    private Player player;
    private PlayerManager playerManager;
    public PlayerPuckSelectionState(PlayerStateMachine stateMachine, Player player)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        playerManager = PlayerManager.Instance;

        inputAction = new MyInputActions();

        inputAction.Mouse.SelectPuck.performed += SelectPuck;
    }
    public override void OnCollisionEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnterState()
    {
        Debug.Log("Sto entrando in PlayerPuckSelectionState");

        inputAction.Enable();
        //rightMouseButton += SelectPuck;
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerPuckSelectionState");

        inputAction.Disable();
        //rightMouseButton -= SelectPuck;
    }

    public override void OnFixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
    }
    //seleziono il puck che verr� mirato
    public void SelectPuck(InputAction.CallbackContext callback)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, playerManager.puckLayerMask))
        {
            PuckBase puck = hit.collider.gameObject.transform?.parent?.parent.GetComponent<PuckBase>();
            Debug.Log(puck);
            if (puck != null && puck.placed == false)
            {
                //hit.collider.enabled = false;
                playerManager.SelectablePuckTT = puck;
                playerManager.puckSelected = puck;
                // TODO: we need to know which side of the board we are on
                // this works for only one side of the board

                // we should use puckController.SetPuck to set the new puck
                // but its position should be in the center of the edge of the current slice
                playerManager.puckController.SetPuck(puck);
                playerManager.puckToThrow = puck;

                stateMachine.SetState(EPlayerState.PlayerPuckPlacement);
            }
        }
    }
}
