using MonitorLib;

namespace TestConsole;

public static class StringConcatTest
{
    public static void Run(int numChars)
    {
        var recorder = new Recorder();
        recorder.Start();

        var concat = new StringConcatenation();
        concat.ConcatenateUsingPlus(numChars);
        
        var result = recorder.Stop();
        RecordingResultWriter.WriteResult($"Concat {numChars} chars using +", result);
    }
}