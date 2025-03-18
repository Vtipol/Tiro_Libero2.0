using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public GenericStateMachine<EPlayerState> StateMachine;
    public EPlayerState firstState;
    public GameObject puckSelected;
    public GameObject puckToThrow;
    public PuckSelectable SelectablePuckTT;

    public StationaryCamera StationaryCamera;
    public FollowPuck FollowPuck;
    public DisableColliders DisableColliders;

    public PuckController puckController;
    public LayerMask puckLayerMask;

    [Header("Aim Var")]
    public LineRenderer lineRenderer;
    public bool invertedAim;
    public bool invertedThrow;
    public float throwForce = 2f;

    //public float sensibilityAim = 1f;
    public float trembling;

    public float minDistanceToThrow;
    public float MaxDistanceToThrow;
    public float tremblingThreshold = 2.5f;
    public float tremblingAmplitude = 0.5f;
    public float tremblingSpeed = 5f;

    [Header("Player Var")]
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
