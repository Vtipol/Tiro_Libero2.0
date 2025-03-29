using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerStateMachine : GenericStateMachine<EPlayerState>
{
    private Player player;
    public PlayerStateMachine(Player player){
        this.player = player;

        RegisterState(EPlayerState.PlayerIdle, new PlayerIdleState(this, player));
        RegisterState(EPlayerState.PlayerPuckSelection, new PlayerPuckSelectionState(this, player));
        RegisterState(EPlayerState.PlayerPuckPlacement, new PlayerPuckPlacementState(this, player));
        RegisterState(EPlayerState.PlayerPuckAiming, new PlayerPuckAimingState(this, player));

        //SetState(EPlayerState.PlayerPuckSelection);
        SetState(EPlayerState.PlayerIdle);

        Debug.Log("PLAYER STATE MACHINE ACTIVATED - "+player.name);
    }
}
