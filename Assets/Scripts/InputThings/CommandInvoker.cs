using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Queue<ICommand> commandQueue = new Queue<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandQueue.Enqueue(command);
    }
}
