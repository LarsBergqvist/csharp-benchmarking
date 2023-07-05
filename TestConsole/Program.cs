using BenchmarkDotNet.Running;
using TestConsole;

const int numChars = 50_000;
StringBuilderTest.Run(numChars);
StringConcatTest.Run(numChars);

BenchmarkRunner.Run<StringConcatenation>();