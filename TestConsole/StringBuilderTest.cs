using MonitorLib;

namespace TestConsole;

public static class StringBuilderTest
{
    public static void Run(int numChars)
    {
        var recorder = new Recorder();
        recorder.Start();

        var concat = new StringConcatenation();
        concat.ConcatenateWithStringBuilder(numChars);
        
        var result = recorder.Stop();
        RecordingResultWriter.WriteResult($"Concat {numChars} chars using StringBuilder", result);

    }
}