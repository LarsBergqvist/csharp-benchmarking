using System;
using System.Diagnostics;
using static System.Diagnostics.Process;

namespace MonitorLib
{
    public class RecordingResult
    {
        public long PhysicalBytesUsed { get; set; }
        public long VirtualBytesUsed { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
    
    public class Recorder
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private long _bytesPhysicalBefore;
        private long _bytesVirtualBefore;

        public void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            _bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            _bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            
            _timer.Restart();
        }

        public RecordingResult Stop()
        {
            _timer.Stop();

            var bytesPhysicalAfter = GetCurrentProcess().WorkingSet64; 
            var bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
            
            return new RecordingResult
            {
                ElapsedTime = _timer.Elapsed,
                VirtualBytesUsed = bytesVirtualAfter - _bytesVirtualBefore,
                PhysicalBytesUsed = bytesPhysicalAfter - _bytesPhysicalBefore
            };
        }
    }
}