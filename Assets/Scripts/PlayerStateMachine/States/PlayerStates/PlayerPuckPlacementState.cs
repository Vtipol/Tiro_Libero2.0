using UnityEngine;

public class PlayerPuckPlacementState : GenericState
{
    private PlayerManager playerManager;
    private PlayerStateMachine stateMachine;
    private Player player;
    public PlayerPuckPlacementState(PlayerStateMachine stateMachine, Player player)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        playerManager = PlayerManager.Instance;
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
        Debug.Log("Sto entrando in PlayerPuckPlacementState");
        playerManager.puckController.InitializePuckPosition();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Place Puck
            playerManager.puckController.enabled = false;
            playerManager.SelectablePuckTT.placed = true;
            stateMachine.SetState(EPlayerState.PlayerPuckAiming);
        }
    }
}
