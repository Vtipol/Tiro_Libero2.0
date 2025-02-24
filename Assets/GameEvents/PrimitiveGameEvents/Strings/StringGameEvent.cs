using UnityEngine;

[CreateAssetMenu(menuName = nameof(GameEvent) + "/"
    + nameof(StringGameEvent)
)]
public class StringGameEvent : GameEvent<string> { }