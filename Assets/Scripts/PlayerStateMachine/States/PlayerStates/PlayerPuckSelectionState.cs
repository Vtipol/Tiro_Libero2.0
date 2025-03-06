using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPuckSelectionState : State
{
    public Action rightMouseButton;

    public PlayerPuckSelectionState(PlayerStateMachine player)
    {
        _owner = player;
    }
    public PlayerStateMachine _owner { get; }
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
        rightMouseButton += SelectPuck;
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerPuckSelectionState");
        rightMouseButton -= SelectPuck;
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
        Debug.Log("Sono nell'update di PlayerPuckSelectionState");
        //al posto di questo if la funzione sarà aggiunta alla
        if (Input.GetMouseButtonDown(0))
        {
            SelectPuck();
        }
    }

    public void SelectPuck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.GetComponent<IPuckInteractable>() != null)
            {
                Debug.Log("oggetto colpito: " + hit.collider.gameObject.name + " che è un puck");
                _owner.puckSelected = hit.collider.gameObject;
                _owner.SetState(EPlayerState.PlayerPuckPlacement);
            }
        }
    }
}
