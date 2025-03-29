using System;
using UnityEngine;
// fa il setup del gioco prima che inizia
public class GamePuckBuildState : GenericState
{
    private GameManager gameManager;
    private GenericStateMachine<GameManagerStates> stateMachine;
    private GamePuckBuilder puckBuilder;
    public GamePuckBuildState(GenericStateMachine<GameManagerStates> stateMachine, GameManager manager)
    {
        this.stateMachine = stateMachine;
        gameManager = manager;
        puckBuilder = GamePuckBuilder.Instance;
        puckBuilder.puckBuilt.AddListener(PuckBuilt);
    }

    public override void OnEnterState()
    {
        puckBuilder.gameObject.SetActive(true);
        puckBuilder.puckBuildingPlayer = gameManager.contextTargettedPlayer;

        puckBuilder.StartBuild();
    }

    private void PuckBuilt(){
        stateMachine.SetState(GameManagerStates.SetupBoard);
    }
}

