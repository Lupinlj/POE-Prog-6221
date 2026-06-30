using System;
using System.Collections.Generic;

namespace POE_PROG_YEAR_2
{
    public static class ActivityLogger
    {
        private static List<string> log = new List<string>();

        public static void Add(string action)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            log.Add($"[{time}] {action}");
        }

        public static string GetLog()
        {
            if (log.Count == 0)
                return "No actions recorded yet.";

            string result = "Recent actions:\n\n";
            int count = 1;
            // Show last 10
            int start = Math.Max(0, log.Count - 10);

            for (int i = start; i < log.Count; i++)
            {
                result += $"{count}. {log[i]}\n";
                count++;
            }
            return result;
        }
    }
}