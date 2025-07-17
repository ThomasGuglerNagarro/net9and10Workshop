using System.Runtime.InteropServices;

namespace ConsoleApp9;
internal class NativeMemoryDemo
{
    internal static void Demo()
    {
        ProcessNativeData();
    }

    // Allocation mémoire non managée avec NativeMemory
    static unsafe void ProcessNativeData()
    {
        byte* buffer = (byte*)NativeMemory.Alloc(1024, sizeof(byte));
        try
        {
            buffer[0] = 0xFF;

        }
        finally
        {
            NativeMemory.Free(buffer);
        }
    }
}
