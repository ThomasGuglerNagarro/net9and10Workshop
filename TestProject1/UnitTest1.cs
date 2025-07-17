using ConsoleApp9;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace TestProject1;

public class UnitTest1
{

    [Fact]
    public void When_AuthoritySender_Reflection_Works()
    {
        var dto = new AnprRecord() { PassageId = "Alice", NotNullableString = "null" };

        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = AnprRecordContext.Default,
            IndentCharacter = ' ',
            IndentSize = 4,
            RespectNullableAnnotations = true,
            RespectRequiredConstructorParameters = true
        };

        // ⚠️ In .NET 9: Dies wirft InvalidOperationException
        var result = JsonSerializer.Serialize(dto, options);
        result.Should().NotBeEmpty();
    }

    [Fact]
    public void When_AuthoritySender_Reflection_Fails()
    {
        var dto = new AnprRecord() { PassageId = "Alice" };

        var o1 = new JsonSerializerOptions
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver() // ❌ kein Resolver → kein Reflection erlaubt
        };

        // ⚠️ In .NET 9: Dies wirft InvalidOperationException
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            JsonSerializer.Serialize(dto, o1);
        });

        Assert.Contains("Reflection-based serialization has been disabled", ex.Message);
    }
}
