using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new SetupBoardState(this));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void SetState(StateMachineState newState)
    {
        stateMachine.ChangeState(newState);
    }
}
