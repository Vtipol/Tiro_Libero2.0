using System;
using UnityEngine;
/*usata per Cambiare gli stati
 * si assicura che esca da uno stato per entrare in un altro
 */
public class StateMachine
{
    private State currentState; 

    public void ChangeState(State newState)
    {
        if (currentState != null)
            currentState.Exit(); 

        currentState = newState;

        if (currentState != null)
            currentState.Enter(); 
    }

    public void Update()
    {
        if (currentState != null)
            currentState.Update(); 
    }
}

