using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;
internal class ScopedDemo
{
    delegate int GetFirst(scoped Span<int> s);

    internal void Demo()
    {
        Span<int> numbers = stackalloc[] { 1, 2, 3 };
        // Func<Span<int>, int> getFirst = s => s[0];

        GetFirst getFirst = (scoped Span<int> s) => s[0];
        Console.WriteLine(getFirst(numbers));
    }
}
