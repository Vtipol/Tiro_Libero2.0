using UnityEngine;

public class PuckMovingState : StateMachineState
{
    private GameManager gameManager;

    public PuckMovingState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Puck is Moving");
        //TODO: disabilità input giocatore
    }
    public override void Update()
    {
        if (Puck.PuckStop()) // Rimpiazza con Check
        {
            Debug.Log(TurnManager.CurrentTurn);
            TurnManager.SwitchTurn(); // Cambio turni
            gameManager.SetState(new InputRegistrationState(gameManager));
            Debug.Log(TurnManager.CurrentTurn);
        }
    }
}
