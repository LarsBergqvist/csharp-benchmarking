using MonitorLib;
using static System.Console;

namespace TestConsole;

public static class RecordingResultWriter
{
    public static void WriteResult(string title, RecordingResult result)
    {
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        WriteLine("Time elapsed: {0} [ms]", result.ElapsedTime.Ticks / (decimal)TimeSpan.TicksPerMillisecond);
        WriteLine("Physical bytes used: {0:N0}", result.PhysicalBytesUsed);
        WriteLine("Virtual bytes used: {0:N0}", result.VirtualBytesUsed);
    }
}