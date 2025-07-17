using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;

// https://github.com/dotnet/runtime/issues/115949
// 1>CSC : warning AD0001: Analyzer 'ILLink.RoslynAnalyzer.DynamicallyAccessedMembersAnalyzer' threw an exception of type 'System.InvalidCastException' with message 'Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Symbols.PublicModel.NonErrorNamedTypeSymbol' to type 'Microsoft.CodeAnalysis.IMethodSymbol'.'.

internal static class ExtensionMembersDemo
{
    internal static void Demo()
    {
        int[] list = [1, 3, 5, 7, 9];
        var x1 = list.ValuesLessThan(3);
        var x2 = MyExtensions.ValuesLessThan(list, 3);
       var x3 = list.ValuesGreaterThan(3);
       var x4 = list.IsEmpty;
    }
}

public static class MyExtensions
{
    public static IEnumerable<int> ValuesLessThan(this IEnumerable<int> source, int threshold)
        => source.Where(x => x < threshold);

    extension(IEnumerable<int> source)
    {
        public IEnumerable<int> ValuesGreaterThan(int threshold)
            => source.Where(x => x > threshold);

        public bool IsEmpty => !source.Any();

        public IEnumerable<int> ValuesGreaterThanZero
        => source.ValuesGreaterThan(0);
    }
}
