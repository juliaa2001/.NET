using System;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace lab2_zadanie3
{
    class Program
    {
        private const string EventLogSource = "SystemMonitor";
        private const string EventLogName = "Application";
        private const int MemoryThreshold = 8; // Procentowy próg zużycia pamięci
        private const int CPULoadThreshold = 10; // Procentowy próg obciążenia CPU

        static void Main(string[] args)
        {
         
            if (!EventLog.SourceExists(EventLogSource))
            {
                EventLog.CreateEventSource(EventLogSource, EventLogName);
            }

            MonitorSystem();
        }

        static void MonitorSystem()
        {
            PerformanceCounter memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            float totalMemory = GetTotalPhysicalMemory();
            while (true)
            {
                float availableMemory = memoryCounter.NextValue();
                float memoryUsagePercentage = ((totalMemory - availableMemory) / totalMemory) * 100;

                float cpuUsage = cpuCounter.NextValue();

                if (memoryUsagePercentage > MemoryThreshold)
                {
                    LogEvent($"Za dużo pamięci jest obecnie w użyciu, oczekiwane: {MemoryThreshold}%, obecnie: {memoryUsagePercentage}%");
                }

                if (cpuUsage < CPULoadThreshold)
                {
                    LogEvent($"Obciążenie CPU mniejsze niż {CPULoadThreshold}%, aktualnie: {cpuUsage}%");
                }

                Thread.Sleep(3000); 
            }
        }

        static float GetTotalPhysicalMemory()
        {
            float totalMemory = 0;

            using (var searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    totalMemory += Convert.ToSingle(obj["Capacity"]) / (1024 * 1024);
                }
            }

            return totalMemory;
        }

        static void LogEvent(string message)
        {
            EventLog.WriteEntry(EventLogSource, message, EventLogEntryType.Warning);
            Console.WriteLine($"[EVENT] {message}");
        }
    }
}
