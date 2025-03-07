
using UnityEngine;
public class PlayerTurnState : StateMachineState
{
    private GameManager gameManager;

    public PlayerTurnState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Player's turn...");
        // TODO:abilita controllo giocatore
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // TODO: cambiare input
        {
            gameManager.SetState(new PuckMovingState(gameManager));
        }
    }
}
