using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public GenericStateMachine<EPlayerState> StateMachine;
    public EPlayerState firstState;
    public GameObject puckSelected;
    public GameObject puckToThrow;

    public LineRenderer lineRenderer;
    public bool invertedAim;
    public float throwForce = 50f;

    public int maxPucks = 7;
    public int myPlacedPucks = 0;
    public bool place1AtTime;

    //lista dei pucks sopravvissuti nella board avversaria
    public List<GameObject> survivedPucks = new List<GameObject>();
    private void Awake()
    {
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;

        StateMachine = new GenericStateMachine<EPlayerState>();

        StateMachine.RegisterState(EPlayerState.PlayerIdle, new PlayerIdleState(this));
        StateMachine.RegisterState(EPlayerState.PlayerPuckSelection, new PlayerPuckSelectionState(this));
        StateMachine.RegisterState(EPlayerState.PlayerPuckPlacement, new PlayerPuckPlacementState(this));
        StateMachine.RegisterState(EPlayerState.PlayerPuckAiming, new PlayerPuckAimingState(this));
        StateMachine.RegisterState(EPlayerState.PlayerWaiting, new PlayerWaitingState(this));

        //SetState(EPlayerState.PlayerPuckSelection);
        SetState(firstState);
    }

    public void SetState(EPlayerState newState)
    {
        StateMachine.SetState(newState);
    }

    void Update()
    {
        StateMachine.OnUpdate();
    }
}
