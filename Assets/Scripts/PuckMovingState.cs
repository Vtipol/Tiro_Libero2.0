using System.Diagnostics;

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
        //TODO: disabilità input giocatore
    }

    public override void Update()
    {
        if (/* Condizione per puck */ false) // Rimpiazza con Check
        {
            gameManager.turnManager.SwitchTurn(); // Cambio turni

            if (gameManager.turnManager.CurrentTurn == TurnManager.Turn.Player)
            {
                gameManager.SetState(new PlayerTurnState(gameManager));
            }
            else
            {
                gameManager.SetState(new EnemyTurnState(gameManager));
            }
        }
    }
}
