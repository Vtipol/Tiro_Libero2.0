using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PuckMovingState : GenericState
{
    private GameManager gameManager;
    private GenericStateMachine<GameManagerStates> stateMachine;
    public bool PuckStill = false;
    public PuckMovingState(GenericStateMachine<GameManagerStates> stateMachine, GameManager manager)
    {
        this.stateMachine = stateMachine;
        gameManager = manager;
    }

   public bool PuckIsStill()
    {
        if(gameManager.puckList.Count == 0) return true;

        var allStill = true;
        foreach( var puck in gameManager.puckList){
            Debug.Log(puck);
            if (puck.GetComponent<Rigidbody>().linearVelocity.magnitude > 0.01f){
                allStill = false;
            }
        }

        return allStill;
    }
    public override void OnEnterState()
    {
        Debug.Log("Puck is Moving");
    }
    public override void OnUpdate()  
    {
        if (PuckIsStill()) 
        {
            stateMachine.SetState(GameManagerStates.PuckMoving);
        }
    }
}
