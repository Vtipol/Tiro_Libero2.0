
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
        GameManager.SetBuildBoardControls(false);
        GameManager.SetControls(true);
    }

    public override void Update()
    {
        if (Input.anyKeyDown) // TODO: cambiare con lancio di disco
        {
            gameManager.SetState(new PuckMovingState(gameManager));
        }
    }
}
