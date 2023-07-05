using System.Text;
using BenchmarkDotNet.Attributes;

namespace TestConsole;

public class StringConcatenation
{
    [Benchmark(Baseline=true)]
    [Arguments(50_000)]
    public string ConcatenateUsingPlus(int numChars)
    {
        var numbers = Enumerable.Range(1, numChars).ToArray();

        var numString = string.Empty;
        foreach (var num in numbers)
        {
            numString += num;
        }

        return numString;
    }

    [Benchmark]
    [Arguments(50_000)]
    public string ConcatenateWithStringBuilder(int numChars)
    {
        var numbers = Enumerable.Range(1, numChars).ToArray();

        var builder = new StringBuilder();
        foreach (var num in numbers)
        {
            builder.Append(num);
        }

        return builder.ToString();
    }
}