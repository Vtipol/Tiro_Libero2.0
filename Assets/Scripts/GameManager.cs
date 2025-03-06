using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private StateMachine stateMachine; //crea e attiva la state machine 

    private void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new SetupBoardState(this)); //inizia con questo stato
    }

    private void Update()
    {
        stateMachine.Update(); // richiama un update sullo stato attivo
    }

    public void SetState(State newState)
    {
        stateMachine.ChangeState(newState);
    }
}

