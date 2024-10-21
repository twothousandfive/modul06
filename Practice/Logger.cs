using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelu1.Practice
{
    public enum LogLevel { INFO, WARNING, ERROR }
    public class Logger
    {
        private Logger(){}

        private static Logger _logger;
        public static LogLevel _level = LogLevel.INFO;

        public static Logger GetInstance()
        {
            if(_logger == null)
                _logger = new Logger();

            return _logger;
        }
        public void SetLevel(LogLevel level)
        {
            _level = level;
        }

        public void Log(string message, LogLevel level)
        {
            if (_level == level) //INFO = INFO
            {
                File.AppendAllText(@"C:\Temp\file.txt",
                    level + " | " + message + Environment.NewLine);
            }
        }
    }
}