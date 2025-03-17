using System;
using UnityEngine;
public abstract class StateMachineState
{

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

