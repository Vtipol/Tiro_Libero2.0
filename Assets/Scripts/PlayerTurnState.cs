using System;
using UnityEngine;

public class PlayerTurnState : State
{
    private GameManager gameManager;

    public PlayerTurnState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Player's turn...");
        //TODO: abiltà controlli giocatore
    }

    public override void Update()
    {
        if (Input.GetMouseButtonUp(0)) //TODO: da cambiare
        { //quando lo "sparo" è rilasciato vai avanti e cambia stato in PuckMovingState
            gameManager.SetState(new PuckMovingState(gameManager));
        }
    }
}

