using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace ConsoleApp9;

// net9: JsonSourceGenerationOptions is a new attribute that can be used to configure the JSON source generation options.
[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(AnprRecord))]
public partial class AnprRecordContext : JsonSerializerContext
{
}

internal static class JsonSerializerOptionsDemo
{
    internal static void Demo()
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = AnprRecordContext.Default,
            IndentCharacter = ' ',
            IndentSize = 4
        };
    }
}
