using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// abbastanza ovvio, il gioco è finito
public class GameOverState : StateMachineState
{
    private GameManager gameManager;
    public static float GameSet = 5;
    public GameOverState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Update()
    {
        if (TurnManager.NumberOfCycles == GameSet)
        {
            gameManager.SetState(new GameOverState(gameManager));
        }
    }

    public override void Enter()
    {
        Debug.Log("Game Over!");
        //TODO: mostra risultati, punteggio, ritorna al main menu, ecc. 
        SceneManager.LoadScene("Main Menu");
    }
}

