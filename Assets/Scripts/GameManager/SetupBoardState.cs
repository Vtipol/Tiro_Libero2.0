using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// fa il setup del gioco prima che inizia
public class SetupBoardState : GenericState
{
    private List<Player> playersToBuild = new List<Player>();
    private bool startMatchSignal = false;
    private GameManager gameManager;
    private GenericStateMachine<GameManagerStates> stateMachine;

    public SetupBoardState(GenericStateMachine<GameManagerStates> stateMachine, GameManager manager)
    {
        this.stateMachine = stateMachine;
        gameManager = manager;
    }
    //It just cycles around all the players while going back and forth this and puck build state, then goes to turn state
    public override void OnEnterState()
    {

        if(playersToBuild.Count == 0){
            if(startMatchSignal){
                startMatchSignal = false;
                gameManager.contextTargettedPlayer = null;
                stateMachine.SetState(GameManagerStates.PlayerTurn);
                return;
            } else {
                playersToBuild.AddRange(PlayerManager.Instance.GetPlayers());
            }
        }

        var player = playersToBuild[0];
        playersToBuild.Remove(player);

        if(playersToBuild.Count == 0) startMatchSignal = true;

        gameManager.contextTargettedPlayer = player;
        Debug.Log("Building "+player);
        stateMachine.SetState(GameManagerStates.PuckBuild);
    }
}

