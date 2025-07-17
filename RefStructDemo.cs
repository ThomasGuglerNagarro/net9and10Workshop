using BenchmarkDotNet.Attributes;

namespace ConsoleApp9;

/*
 | Method           | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
   |----------------- |----------:|----------:|----------:|----------:|-------:|----------:|
   | StructVersion    | 15.387 ns | 0.6444 ns | 1.8281 ns | 14.874 ns | 0.0140 |      88 B |
   | RefStructVersion |  9.604 ns | 0.2190 ns | 0.2049 ns |  9.584 ns |      - |         - |
 */
/*
 | Method           | Mean     | Error    | StdDev   | Median    | Gen0   | Allocated |
   |----------------- |---------:|---------:|---------:|----------:|-------:|----------:|
   | StructVersion    | 15.12 ns | 0.464 ns | 1.331 ns | 14.623 ns | 0.0140 |      88 B |
   | RefStructVersion | 10.37 ns | 0.405 ns | 1.129 ns |  9.889 ns |      - |         - |
   
 */

public struct MyStruct
{
    private int[] data;

    public MyStruct(int size)
    {
        data = new int[size];
        for (int i = 0; i < size; i++) data[i] = i;
    }

    public int Sum()
    {
        int sum = 0;
        for (int i = 0; i < data.Length; i++) sum += data[i];
        return sum;
    }
}

public ref struct MyRefStruct
{
    private Span<int> data;

    public MyRefStruct(Span<int> span)
    {
        data = span;
        for (int i = 0; i < data.Length; i++) data[i] = i;
    }

    public int Sum()
    {
        int sum = 0;
        for (int i = 0; i < data.Length; i++) sum += data[i];
        return sum;
    }
}

[MemoryDiagnoser]
public class StructVsRefStructBenchmarks
{
    private const int Size = 16;

    [Benchmark]
    public int StructVersion()
    {
        var s = new MyStruct(Size);
        return s.Sum();
    }

    [Benchmark]
    public int RefStructVersion()
    {
        Span<int> buffer = stackalloc int[Size];
        var rs = new MyRefStruct(buffer);
        return rs.Sum();
    }
}