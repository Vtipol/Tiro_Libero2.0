using UnityEngine;

public class WeightPuck : Puck
{
    protected override void ApplyPuckSettings()
    {
        base.ApplyPuckSettings();
        _rigidbody.mass *= 2f; // Doubles the weight
        Debug.Log("WeightPuck: Weight increased.");
    }
}
