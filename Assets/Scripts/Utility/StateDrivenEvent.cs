using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateDrivenEvent : MonoBehaviour
{
    [SerializeField] private List<StateEvent> _stateEventsList;

    private Dictionary<MachineState, UnityEvent> _stateEvents;

    private MachineState _currentState;

    private void Awake()
    {
        FillDictionary();
    }

    // Translates the List to a Dictionary for quicker access
    private void FillDictionary()
    {
        _stateEvents = new();

        for (int i = 0; i < _stateEventsList.Count; i++)
        {
            StateEvent stateEvent = _stateEventsList[i];
            _stateEvents[stateEvent.State] = stateEvent.UnityEvent;
        }
    }

    public void Invoke()
    {
        if (_currentState != null)
        { 
                        
        }

        if (!_stateEvents.ContainsKey(_currentState))
        {
            Debug.LogWarning("");
        }

        _stateEvents[_currentState].Invoke();
    }

    public void SetState(MachineState state)
    {
        _currentState = state;
    }
}
