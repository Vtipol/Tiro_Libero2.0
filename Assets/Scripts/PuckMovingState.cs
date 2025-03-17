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
        GameManager.SetControls(false);
    }
    public override void Update()  
    {
        if (Puck.PuckStop()) // Rimpiazza con Check
        {
            TurnManager.SwitchTurn(); // Cambio turni
            gameManager.SetState(new SetupBoardState(gameManager));
            Debug.Log(TurnManager.CurrentTurn);
        }
    }
}
