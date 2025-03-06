using System;
using UnityEngine;
/*la classe base per tutti gli stati
utilizzo una classe astratta per così tutti posso ereditare
*/
public abstract class State
{
    
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

