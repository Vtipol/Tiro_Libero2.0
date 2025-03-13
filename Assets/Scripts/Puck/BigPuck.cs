using UnityEngine;

public class BigPuck : Puck
{
    protected override void ApplyPuckSettings()
    {
        base.ApplyPuckSettings();
        transform.localScale *= 1.5f; // Increases size by 50%
        Debug.Log("BigPuck: Scale increased.");
    }
}
