using UnityEngine;

public class WeightPuck : PuckAbstract
{
    protected override void ApplyPuckSettings()
    {
        base.ApplyPuckSettings();
        _rigidbody.mass *= 2f; // Doubles the weight
        Debug.Log("WeightPuck: Weight increased.");
    }
}
