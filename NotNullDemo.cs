using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;

public static class NotNullDemo
{
    public static void Run()
    {
        Process("sdfsddfs");
    }

    // The 'notnull' constraint ensures that T cannot be a nullable type.
    // comes with C# 11 and .NET 7
    internal static void Process<T>(T element) where T : notnull
    {
        Console.WriteLine(element);
    }
}
