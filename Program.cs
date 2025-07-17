using System.Buffers.Text;
using BenchmarkDotNet.Running;
using ConsoleApp9;

/*
// new Base64Url.EncodeToString
ReadOnlySpan<byte> data = "Hallo Sample World"u8 + "more data to test the encoding?"u8;
var base64urlDol = Convert.ToBase64String(data); // .Replace("/", "");
var base64urlNew = Base64Url.EncodeToString(data);

// FromSeconds bugfix
var a = TimeSpan.FromSeconds(64.823); // was a rounding bug in .net8
var b = TimeSpan.FromSeconds(64, 823); // new
*/

// Null-conditional assignment
/* var user = new User();
user?.Name = "adsfsf";
*/

// works now
Console.WriteLine(nameof(List<>));

Feature.DoIt();

// ExtensionMembersDemo.Demo();
// SpanDemo.Demo();
// NativeMemoryDemo.Demo();
// await ChannelDemo.Demo();
// new LoggingDemo().Demo();
// BenchmarkRunner.Run<StructVsRefStructBenchmarks>();

internal class User
{
    public string? Name { get; set; }
}

