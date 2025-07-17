using BenchmarkDotNet.Attributes;

namespace ConsoleApp9;

public partial class MyClass
{
    public void DoWork()
    {
        Log("Starte Arbeit...");
        // ... Arbeit wird ausgeführt ...
        Log("Arbeit abgeschlossen.");
    }

    // Erst Deklaration
    public partial void Log(string message);
    // partial-Methode mit Implementierung (neu in C# 13)
    public partial void Log(string message) => Console.WriteLine($"[LOG] {message}");
}

ref partial struct MyFile(): IDisposable // ref struct can not implement IDisposable, even ref structs can live only on the stack, not on the heap
{
    public partial Span<byte> Map { get; private set; } // partial property
    public partial void Dispose();
}

// generated code; with new Lock keyword in C# 12, you can use a struct for locking instead of an object
ref partial struct MyFile
{
    Span<byte> map;
    Lock mapLock = new(); // not object
    public partial Span<byte> Map
    {
        get;
        private set {
            lock (mapLock)
            {
                field = value;
            }
        }
    }
    public partial void Dispose() => Map = default; // Clear the span when disposing
}
