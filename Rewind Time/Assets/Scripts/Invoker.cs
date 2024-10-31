using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private Command command;
    public bool disableLog;

    public void Setcommand(Command commandValue)
    {
        command = commandValue;

    }

    public void ExcuteCommand()
    {
        if (!disableLog)
        {
            CommandLog.commands1.Enqueue(command);
        }
        command.Execute();
    }
}
