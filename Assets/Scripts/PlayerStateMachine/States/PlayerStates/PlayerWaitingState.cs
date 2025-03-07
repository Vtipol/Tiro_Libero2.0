using UnityEngine;

public class PlayerWaitingState : State
{
    public PlayerWaitingState(PlayerStateMachine player)
    {
        _owner = player;
    }
    public PlayerStateMachine _owner { get; }
    public override void OnCollisionEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnterState()
    {
        Debug.Log("Sto entrando in PlayerWaitingState");
        //manda un segnale al game manager che gli dice di andare in movement state
        //o faccio un controllo sui miei puck per vedere se sono fermi o "tiri nulli" e controllo tutti
        //i puck presenti sulla board, o intanto mando un segnale al game manager.

        Debug.Log("mando un segnale al game manager che mi controlla se tutti i puck sono fermi");
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerWaitingState");
    }

    public override void OnFixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        Debug.Log("Sono nell'update di PlayerWaitingState");
    }
}
