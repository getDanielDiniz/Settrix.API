using System.Collections;

namespace IntegrationTests.InlineData;

public class CulturesInlineData : IEnumerable<object[]>
{
    public IEnumerator<Object[]> GetEnumerator()
    {
        yield return ["en"];
        yield return ["pt-BR"];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}