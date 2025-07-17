namespace ConsoleApp9;
internal class LockSample
{
    private readonly Lock _lock = new Lock();
    internal void Process()
    {
        // lock (_lock) => also works, but EnterScope is preferred for better readability and exception safety
        using (_lock.EnterScope())
        {
            // Critical section code goes here
        }
    }
}
