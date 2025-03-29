using System;
using System.Collections.Generic;
/// <summary>
/// Macchina a Stati Finiti
/// </summary>
/// <typeparam name="T">Enumeratore</typeparam>
public class GenericStateMachine<T> where T : Enum 
{
    private Dictionary<T, GenericState> _allStates = new Dictionary<T, GenericState>();
    private GenericState _currentState;

    // per debug usiamo queste propriet�
    public T PreviousStateType; // stato dal quale sto uscendo
    public T CurrentStateType; // stato attuale, in generale il nuovo stato in cui sto entrando

    public void RegisterState(T stateType, GenericState state)
    {
        if (_allStates.ContainsKey(stateType))
        {
            throw new InvalidOperationException($"Esiste gi� uno stato {stateType}");
        }

        _allStates.Add(stateType, state);
    }

    public void SetState(T stateEnum)
    {
        if (!_allStates.ContainsKey(stateEnum))
        {
            throw new InvalidOperationException($"Non esiste alcuno stato {stateEnum}");
        }

        PreviousStateType = CurrentStateType; // per debug

        _currentState?.OnExitState(); // chiamo la funzione che mi fa uscire dallo stato in cui sono, se esiste. aka onEnd

        CurrentStateType = stateEnum; // per debug

        _currentState = _allStates[stateEnum]; // seleziono lo stato che ho passato come parametro

        _currentState.OnEnterState(); // entro nel nuovo stato, aka start state
    }

    public void OnUpdate() => _currentState?.OnUpdate();
    public void OnFixedUpdate() => _currentState?.OnFixedUpdate();
    public void OnTriggerEnter() => _currentState?.OnTriggerEnter();
    public void OnTriggerExit() => _currentState?.OnTriggerExit();
    public void OnCollisionEnter() => _currentState?.OnCollisionEnter();
    public void OnCollisionExit() => _currentState?.OnCollisionExit();
}
