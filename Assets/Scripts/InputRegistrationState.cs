using System;
using UnityEngine;
// il gioco aspetta il giocatore prima che inizia, dopo l'input va avanti
public class InputRegistrationState : StateMachineState
{
    private GameManager gameManager;

    public InputRegistrationState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Waiting for player input...");
        //TODO: abilità l'input sistem a 
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0)) // TODO: Da cambiare
        {
            gameManager.SetState(new PlayerTurnState(gameManager));
        }
    }
}

