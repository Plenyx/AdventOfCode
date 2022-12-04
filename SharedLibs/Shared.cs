using System.Diagnostics;

namespace SharedLibs
{
    public static class Shared
    {
        private static readonly Stopwatch executionTimer = new();

        public static ReadOnlySpan<string> LoadFromFileAsSpan(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName).AsSpan();
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public static void StartExecutionTimer()
        {
            executionTimer.Start();
        }

        public static TimeSpan StopAndReturnExecutionTimer()
        {
            executionTimer.Stop();
            var timer = executionTimer.Elapsed;
            executionTimer.Restart();
            return timer;
        }

        public static void StopAndWriteExecutionTimer()
        {
            Console.WriteLine($"Program finished after: {StopAndReturnExecutionTimer()}");
        }
    }
}
