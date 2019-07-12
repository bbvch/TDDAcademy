namespace TddAcademy;

public interface ITaskDispatcher
{
    string GetTask();

    void FinishedTask(string task);
}