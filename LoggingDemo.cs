using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;

/*
 | Method                 | Mean        | Error       | StdDev      | Allocated | Alloc Ratio |
   |----------------------- |------------:|------------:|------------:|----------:|------------:|
   | InterpolatedLogging    | 74,690.3 ns | 1,399.59 ns | 2,890.40 ns |  120000 B |        1.00 |
   | StructuredLogging      | 31,211.9 ns |   547.98 ns |   586.33 ns |   88000 B |        0.73 |
   | HighPerformanceLogging |    896.1 ns |    11.07 ns |    10.35 ns |         - |        0.00 |
 */
internal class LoggingDemo
{
    internal void Demo()
    {
        // .NET 9 introduces a new logging API that simplifies logging setup and usage.
        // Example of setting up a simple logger
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole(); // Add console logging
            builder.SetMinimumLevel(LogLevel.Information); // Set minimum log level
        });

        var logger = loggerFactory.CreateLogger<LoggingDemo>();
        // string interpolation:
        var user = new { Id = 1, Name = "Goat" };
        var loginTime = DateTime.Now;
        logger.LogInformation($"Goat number {user.Id} logged in at {loginTime}");
        // Logging with structured data with templates:
        logger.LogInformation("User logged in: {User}", user);
        // High-performance logging with LoggerMessageAttribute
        logger.UserLoggedIn(user.Id, loginTime);
    }
}

internal static partial class HighPerformanceLoggingExtensions
{
    [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = "Goat number {Id} logged in at {LoginTime}")]
    public static partial void UserLoggedIn(this ILogger logger, int id, DateTime loginTime);
}
