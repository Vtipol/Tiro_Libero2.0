using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurnState : GenericState
{
    private List<Player> playersToTurn = new List<Player>();
    private bool nextTurnSignal;
    private int currentTurn;
    private GameManager gameManager;
    private GenericStateMachine<GameManagerStates> stateMachine;

    public PlayerTurnState(GenericStateMachine<GameManagerStates> stateMachine, GameManager manager)
    {
        gameManager = manager;
        this.stateMachine = stateMachine;

        PlayerManager.Instance.playerTurnEndSignal += OnPlayerTurnEnd;
    }

    public override void OnEnterState()
    {
        if(playersToTurn.Count == 0){
            if(nextTurnSignal){
                currentTurn++;
                nextTurnSignal = false;
                if(currentTurn > gameManager.turnsBeforeGameEnd){
                    gameManager.contextTargettedPlayer = null;
                    stateMachine.SetState(GameManagerStates.PlayerTurn);
                    return;
                }

            } else {
                Debug.Log("Player's turn...");
                currentTurn = 1;
            }
            playersToTurn.AddRange(PlayerManager.Instance.GetPlayers());
        }

        var player = playersToTurn[0];
        playersToTurn.Remove(player);

        if(playersToTurn.Count == 0) nextTurnSignal = true;

        gameManager.contextTargettedPlayer = player;
        Debug.Log("Player Turn "+player);
        GamePuckDisplay.Instance.DisplayPucks(player);

        player.startPlayerTurnSignal?.Invoke();
    }

    public void OnPlayerTurnEnd(){
        GamePuckDisplay.Instance.ClearPucks();
        stateMachine.SetState(GameManagerStates.PlayerTurn);
    }
}

