using System.Diagnostics;

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
        // TODO:abilita controllo giocatore
    }

    public override void Update()
    {
        if (Input.GetMouseButtonUp(0)) // TODO: cambiare input
        {
            gameManager.SetState(new PuckMovingState(gameManager));
        }
    }
}
