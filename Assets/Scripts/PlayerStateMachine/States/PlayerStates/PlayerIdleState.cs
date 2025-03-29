using UnityEngine;

public class PlayerIdleState : GenericState
{
    private PlayerStateMachine stateMachine;
    private Player player;
    public PlayerIdleState(PlayerStateMachine stateMachine, Player player)
    {
        this.player = player;
        this.stateMachine = stateMachine;

        player.startPlayerTurnSignal += StartPlayerTurnSignal;
    }

    public override void OnEnterState()
    {
        Debug.Log("Sto entrando in PlayerIdle");
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerIdle");
    }

    public void StartPlayerTurnSignal(){
        stateMachine.SetState(EPlayerState.PlayerPuckSelection);
    }
}
