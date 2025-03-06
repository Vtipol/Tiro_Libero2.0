using UnityEvents;

public class GameManager : MonoBehaviour
{
    private StateMachine stateMachine;
    public TurnManager turnManager { get; private set; }

    private void Start()
    {
        turnManager = new TurnManager();
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new SetupBoardState(this));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void SetState(State newState)
    {
        stateMachine.ChangeState(newState);
    }
}
