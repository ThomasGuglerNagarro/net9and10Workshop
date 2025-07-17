using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp9;
public class Job
{
    public string Name { get; set; }
    public int Priority { get; set; } // kleinere Zahl = höhere Priorität
}

public class JobPriorityComparer : IComparer<Job>
{
    public int Compare(Job? x, Job? y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Nullwert im Vergleich");

        return x.Priority.CompareTo(y.Priority); // kleiner = höhere Priorität
    }
}

internal static class ChannelDemo
{
    internal static async Task Demo()
    {
        var ch = Channel.CreateUnbounded<Job>();
        /*
        var ch = Channel.CreateUnboundedPrioritized<Job>(new UnboundedPrioritizedChannelOptions<Job>()
            {
            Comparer = new JobPriorityComparer(),
            SingleReader = true, // Nur ein Leser
            SingleWriter = true  // Nur ein Schreiber
        });*/

        await ch.Writer.WriteAsync(new Job { Name = "Niedrig", Priority = 5 });
        await ch.Writer.WriteAsync(new Job { Name = "Hoch", Priority = 1 });
        await ch.Writer.WriteAsync(new Job { Name = "Mittel", Priority = 3 });
        ch.Writer.Complete();

        /*
        await foreach (var job in ch.Reader.ReadAllAsync())
        {
            Console.WriteLine($"Verarbeite Job: {job.Name} (Prio {job.Priority})");
        }*/

        while (await ch.Reader.WaitToReadAsync())
        while (ch.Reader.TryRead(out Job item))
            Console.WriteLine(item.Name); // Ausgabe: 1, 3, 5
    }

    internal static async Task Demo2()
    {
        // Creating an unbounded channel (can store unlimited elements)
        var channel = Channel.CreateUnbounded<int>();
        // var channel = Channel.CreateUnboundedPrioritized<int>();

        // Starting the producer
        var producerTask = Task.Run(() => ProduceDataAsync(channel.Writer));

        // Starting the consumer
        var consumerTask = Task.Run(() => ConsumeDataAsync(channel.Reader));

        // Waiting for both tasks to complete
        await Task.WhenAll(producerTask, consumerTask);

        Console.WriteLine("Processing completed.");
    }

    // Producer method
    static async Task ProduceDataAsync(ChannelWriter<int> writer)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Producing data: {i}");
            await writer.WriteAsync(i); // Sending data to the channel
            await Task.Delay(100); // Simulating production delay
        }

        writer.Complete(); // Indicates producer has finished
    }

    // Consumer method
    static async Task ConsumeDataAsync(ChannelReader<int> reader)
    {
        await foreach (var item in reader.ReadAllAsync()) // Reading data from channel
        {
            Console.WriteLine($"Consuming data: {item}");
            await Task.Delay(500); // Simulating processing delay
        }
    }
}
