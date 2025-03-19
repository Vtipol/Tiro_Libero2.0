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
    //seleziono il puck che verrà mirato
    public void SelectPuck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            PuckSelectable puckSelectable = hit.collider.gameObject.GetComponent<PuckSelectable>();
            if (puckSelectable != null && puckSelectable.placed == false)
            {
                //hit.collider.enabled = false;
                _owner.SelectablePuckTT = puckSelectable;
                _owner.puckSelected = puckSelectable.puck;
                // TODO: we need to know which side of the board we are on
                // this works for only one side of the board

                // we should use puckController.SetPuck to set the new puck
                // but its position should be in the center of the edge of the current slice
                _owner.puckSelected.transform.position = _owner.puckController.Puck.transform.position;

                _owner.SetState(EPlayerState.PlayerPuckPlacement);
            }
        }
    }
}
