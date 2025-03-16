using System;
using UnityEngine;
// fa il setup del gioco prima che inizia
public class SetupBoardState : StateMachineState
{
    private GameManager gameManager;

    public SetupBoardState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log($"{TurnManager.CurrentTurn} is Setting up the board...");
        GameManager.SetBuildBoardControls(true);
                                //Muovi a VVV dopo il setup 
        gameManager.SetState(new PlayerTurnState(gameManager));
    }
}

