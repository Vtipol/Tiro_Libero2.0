using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PuckMovingState : StateMachineState
{
    private GameManager gameManager;
    public bool PuckStill = false;
    public PuckMovingState(GameManager manager)
    {
        gameManager = manager;
    }
    public void PuckisStill()
    {
        PuckAbstract.PuckStop += PuckIsStill;
    }
   public void PuckIsStill()
    {
        PuckStill = true;
    }
    public override void Enter()
    {
        Debug.Log("Puck is Moving");
        gameManager.SetControls(false);
    }
    public override void Update()  
    {
        if (PuckStill) 
        {
            TurnManager.SwitchTurn(); // Cambio turni
            gameManager.SetState(new PlayerTurnState(gameManager));
            Debug.Log(TurnManager.CurrentTurn);
        }
    }
}
