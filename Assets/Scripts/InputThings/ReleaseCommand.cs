using UnityEngine;

//Command : rilascio del tiro 
public class ReleaseCommand : ICommand
{
    private Slingshot slingshot;

    public ReleaseCommand(Slingshot slingshot)
    {
        this.slingshot = slingshot;
    }
    public void Execute()
    {
        slingshot.Release();
    }
}
