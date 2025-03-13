using UnityEngine;

public class PlayerPuckPlacementState : State
{
    public PlayerPuckPlacementState(PlayerStateMachine player)
    {
        _owner = player;
    }
    public PlayerStateMachine _owner { get;}
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
        Debug.Log("Sto entrando in PlayerPuckPlacementState");
        _owner.puckController.enabled = true;

        _owner.puckController.puck.SetActive(false);
        _owner.puckController.puck = _owner.puckSelected;
        _owner.puckController.InitializePuckPosition();
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerPuckPlacementState");
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
        Debug.Log("Sono nell'update di PlayerPuckPlacementState");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Place Puck
            _owner.puckController.enabled = false;
            _owner.SelectablePuckTT.placed = true;
            _owner.SetState(EPlayerState.PlayerPuckAiming);
        }
    }
}
