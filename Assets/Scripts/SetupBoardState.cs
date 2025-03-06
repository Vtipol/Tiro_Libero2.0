using System;
using UnityEngine;
// fa il setup del gioco prima che inizia
public class SetupBoardState : State
{
    private GameManager gameManager;

    public SetupBoardState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Setting up the board...");
        // TODO: mettere Puck, Resetta lo score
                                //Muovi a VVV dopo il setup 
        gameManager.SetState(new InputRegistrationState(gameManager));
    }
}

