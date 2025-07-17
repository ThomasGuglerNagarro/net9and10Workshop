namespace ConsoleApp9;

internal static class LinqDemo
{
    record CompletedLession(long CourceId, long LessionId, long LessionDurationSeconds);

    internal static void Demo()
    {
        var totelWatchTime = new List<(long CourceId, long LessionDurationSeconds)>();
        var completedLessons = new List<CompletedLession>()
        {
            new(1, 1, 434),
            new(1, 1, 764),
            new(2, 1, 347),
            new(2, 3, 424),
            new(3, 1, 69)
        };

        foreach (var completedLession in completedLessons)
        {
            totelWatchTime.Add((completedLession.CourceId, completedLession.LessionDurationSeconds));
        }

        /* old GroupBy
        totelWatchTime.GroupBy(tuple => tuple.CourceId)
            .Select(group => new
            {
                CourceId = group.Key,
                TotalDuration = group.Sum(tuple => tuple.LessionDurationSeconds)
            })
            .ToList()
            .ForEach(result => Console.WriteLine($"CourceId: {result.CourceId}, Total Duration: {result.TotalDuration} seconds"));
        */
        // New AggregateBy
        var courseWatchTime = totelWatchTime.AggregateBy(x => x.CourceId, _ => 0m,
            (seconds, item) => decimal.Add(seconds, item.LessionDurationSeconds));
        foreach (var pair in courseWatchTime)
        {
            Console.WriteLine($"CourceId: {pair.Key}, Total Duration: {pair.Value} seconds.");
        }
        // new CountBy
        foreach (var pair in completedLessons.CountBy(x => x.LessionId))
        {
            Console.WriteLine($"LessionId: {pair.Key}, Was watched : {pair.Value} times.");
        }
    }
}