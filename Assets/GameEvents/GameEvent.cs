using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventBase : ScriptableObject { }

[Serializable]
public class GameEvent<T> : GameEventBase
{
    private readonly List<GameEventListener<T>> _listeners = new();

    public void Raise(T data)
    {
        for (int i = _listeners.Count - 1; i > -1; i--)
        {
            _listeners[i].OnEventRaised(data);
        }
    }

    public void AddListener(GameEventListener<T> gameEventListener)
    {
        _listeners.Add(gameEventListener);
    }

    public void RemoveListener(GameEventListener<T> gameEventListener)
    {
        _listeners.Remove(gameEventListener);
    }
}

[CreateAssetMenu(menuName = nameof(GameEvent) + "/"
    + nameof(GameEvent)
)]
// A gameEvent that doesn't require any data to be passed
public class GameEvent : GameEvent<Unit>
{
    // needed as struct can't be seen from the inspector
    // this is actually what we want, letting us raise the event without any data
    public void Raise() => Raise(Unit.Default);
}

// A struct used to let us pass no data to the GameEvent and GameEventListener
public struct Unit
{
    public static Unit Default => default;
}