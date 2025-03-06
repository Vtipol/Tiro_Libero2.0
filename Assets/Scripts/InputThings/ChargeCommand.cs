using UnityEngine;

//Command: carica il tiro
public class ChargeCommand : ICommand
{
    private Slingshot slingshot;
    private Vector3 _pullPosition;

    public ChargeCommand(Slingshot slingshot, Vector3 pullPosition)
    {
        this.slingshot = slingshot;
        this._pullPosition = pullPosition;
    }
    
    public void Execute()
    {
        slingshot.Charge(_pullPosition);
    }

    
}
