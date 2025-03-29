using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : Singleton<GameManager>
{
    public List<PuckBase> puckList = new List<PuckBase>();
    private GenericStateMachine<GameManagerStates> stateMachine;
    private MyInputActions inputActions;
    public Player contextTargettedPlayer;
    public int turnsBeforeGameEnd = 3;
    public static bool ControlsEnabled { get; private set; } = false;
    //public static bool BuildBoardControls { get; private set; } = false;
    private void Start()
    {

        stateMachine = new GenericStateMachine<GameManagerStates>();

        stateMachine.RegisterState(GameManagerStates.GameOver, new GameOverState(stateMachine, this));
        stateMachine.RegisterState(GameManagerStates.SetupBoard, new SetupBoardState(stateMachine, this));
        stateMachine.RegisterState(GameManagerStates.PlayerTurn, new PlayerTurnState(stateMachine, this));
        stateMachine.RegisterState(GameManagerStates.PuckMoving, new PuckMovingState(stateMachine, this));
        stateMachine.RegisterState(GameManagerStates.PuckBuild, new GamePuckBuildState(stateMachine, this));

        stateMachine.SetState(GameManagerStates.SetupBoard);
    }
    public void OnGameStart()
    {
        stateMachine.SetState(GameManagerStates.SetupBoard);
    }
    private void Update()
    {
        stateMachine.OnUpdate();
    }
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
