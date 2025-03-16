using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private StateMachine stateMachine;
    public static bool ControlsEnabled { get; private set; } = false;
    public static bool BuildBoardControls { get; private set; } = false;
    private void Start()
    {
        stateMachine = new StateMachine();
    }
    private void OnGameStart()
    {
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

    public static void SetBuildBoardControls(bool enabled)
    {
        BuildBoardControls = enabled;
    }
    public static void SetControls(bool enabled)
    { 
        ControlsEnabled = enabled;
    }
    
}
