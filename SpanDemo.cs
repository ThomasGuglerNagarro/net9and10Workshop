namespace ConsoleApp9;
internal class SpanDemo
{
    internal static void Demo()
    {
        NewReadOnlySpan();
        ParamsIEnumerableNew(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        SplitStringNew();
    }

    private static void SplitStringNew()
    {
        string input = "Hello,World,This,Is,A,Test";
        ReadOnlySpan<char> inputSpan = input;
        // works now:
        File.WriteAllText("outpot.txt", inputSpan);
        // split demo:
        MemoryExtensions.SpanSplitEnumerator<char> ranges = inputSpan.Split(',');
        foreach (var range in ranges)
        {
            ReadOnlySpan<char> part = inputSpan[range];
            Console.WriteLine(part.ToString()); // Print each split part
        }
    }

    private static void ParamsIEnumerableOld(params IEnumerable<int> numbers)
    {
        var sum = numbers.Sum();
        Console.WriteLine($"Sum of all numbers: {sum}");
    }
    private static void ParamsIEnumerableNew(params ReadOnlySpan<int> numbers)
    {
        var sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"Sum of all numbers: {sum}");
    }
    private static void NewReadOnlySpan()
    {
        ReadOnlySpan<char> data = "Hello, World!";

        var dic = new Dictionary<string, int>()
        {
            { "Hello", 69 },
            { " World!", 420 }
        };

        var splitRange = data.Split(',');
        var altDic = dic.GetAlternateLookup<ReadOnlySpan<char>>();

        foreach (var range in splitRange)
        {
            ReadOnlySpan<char> key = data[range];
            Console.WriteLine(altDic[key]);
            // Console.WriteLine(key.ToString()); // Print each split part
        }
    }

    private static void OldString()
    {
        // ReadOnlySpan<char>
        var data = "Hello, World!";

        var dic = new Dictionary<string, int>()
        {
            { "Hello", 69 },
            { ", World!", 420 }
        };

        Console.WriteLine(dic[data.Split(',')[0]]);
    }

}
