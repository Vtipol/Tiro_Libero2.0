public abstract class GenericState
{
    // -- questi metodi sono fondamentali
    public virtual void OnEnterState(){}
    public virtual void OnExitState(){}
    public virtual void OnUpdate(){}
    public virtual void OnFixedUpdate(){}
    // --

    // -- questi metodi sono opzionali in base alla struttura del codice
    public virtual void OnTriggerEnter(){}
    public virtual void OnTriggerExit(){}
    public virtual void OnCollisionEnter(){}
    public virtual void OnCollisionExit(){}
    // --
}
