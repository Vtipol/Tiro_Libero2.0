using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : Singleton<GameManager>
{
    private StateMachine stateMachine;
    private MyInputActions inputActions;
    public static bool ControlsEnabled { get; private set; } = false;
    //public static bool BuildBoardControls { get; private set; } = false;
    private void Start()
    {
        stateMachine = new StateMachine();
    }
    public void OnGameStart()
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
/*
    public static void SetBuildBoardControls(bool enabled)
    {
        BuildBoardControls = enabled;
    }
    */
    public void SetControls(bool enabled)
    { 
            if (enabled)
            {
                inputActions.Enable();  
            }
            else
            {
                inputActions.Disable(); 
            }
    }
}
