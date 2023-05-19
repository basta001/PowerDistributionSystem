using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Loggers
{
    public class Logger : ILogger
    {
        private readonly string _logFilePath;
        private readonly bool _logToConsole;

        public Logger(string filePath, bool logToConsole = false)
        {
            _logFilePath = filePath;
            _logToConsole = logToConsole;
        }

        public void Error(string message)
        {
            Log(message);
        }

        public void Info(string message)
        {
            Log(message);
        }

        public void Warn(string message)
        {
            Log(message);
        }

        private void Log(string message, [CallerMemberName] string severity = "")
        {
            string line = $"[{DateTime.Now}]\t[{severity.ToUpper()}]\t{message}";

            using (StreamWriter writer = new StreamWriter(_logFilePath))
            {
                writer.WriteLine(line);

                if (_logToConsole)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
