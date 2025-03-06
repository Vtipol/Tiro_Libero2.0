using System;
using UnityEngine;
// abbastanza ovvio, il gioco è finito
public class GameOverState : State
{
    private GameManager gameManager;

    public GameOverState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Game Over!");
        //TODO: mostra risultati, punteggio, ritorna al main menu, ecc. 
    }
}

