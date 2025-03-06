using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public GenericStateMachine<EPlayerState> StateMachine;
    public EPlayerState firstState;
    public GameObject puckSelected;
    public GameObject puckToShoot;

    public int maxPucks = 7;
    public int placedPucks = 0;


    private void Awake()
    {
        StateMachine = new GenericStateMachine<EPlayerState>();

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
