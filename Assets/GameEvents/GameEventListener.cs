using UnityEngine;
using UnityEngine.Events;

public class GameEventListener<T> : MonoBehaviour
{
    [SerializeField] private GameEvent<T> _gameEvent;
    [SerializeField] private UnityEvent<T> _event;

    public void OnEventRaised(T data) => _event.Invoke(data);

    private void OnEnable() => _gameEvent.AddListener(this);
    private void OnDisable() => _gameEvent.RemoveListener(this);
}

// differently from the GameEvent class, we don't need to create a method with no paremeters
// as it doesn't need to be seen from the inspector,
// still, it's gonna be "public void OnEventRaised(Unit data) => _event.Invoke(data);" and work as expected,
// passing in fact nothing
public class GameEventListener : GameEventListener<Unit> { }