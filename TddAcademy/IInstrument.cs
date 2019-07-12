using System;

namespace TddAcademy;

public interface IInstrument
{
    void Execute(string task);

    event EventHandler<TaskEventArgs> Finished;
    event EventHandler<TaskEventArgs> Error;
}