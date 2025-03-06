using System;
using UnityEngine;
// Quando il puck si smette di muovere allora cambia stato
public class PuckMovingState : State
{
    private GameManager gameManager;

    public PuckMovingState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Puck is moving...");
        //TODO: Disabilità l'input del giocatore quando è in questo stato
    }

    public override void Update()
    {
        if (/* Condizione: Puck Fermo = */ false)  //TODO: cambiare questa condizione.
        {
            gameManager.SetState(new GameOverState(gameManager));
        }
    }
}

