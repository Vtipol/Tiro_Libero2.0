using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// abbastanza ovvio, il gioco è finito
public class GameOverState : GenericState
{
    private GameManager gameManager;
    private GenericStateMachine<GameManagerStates> stateMachine;
    public GameOverState(GenericStateMachine<GameManagerStates> stateMachine, GameManager manager)
    {
        gameManager = manager;
        this.stateMachine = stateMachine;
    }

    public override void OnEnterState()
    {
        Debug.Log("Game Over!");
        //TODO: mostra risultati, punteggio, ritorna al main menu, ecc. 
        SceneManager.LoadScene("Main Menu");
    }
}

