using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public enum LogLevel
    {
        INFO,
        DEBUG,
        ERROR
    }

    public abstract class Logger
    {
        protected LogLevel m_logLevel;

        protected Logger m_nextLogger;

        public void SetNextLogger(Logger logger)
        {
            m_nextLogger = logger;
        }

        public void LogMessage(LogLevel level, string message)
        {
            if(level <= m_logLevel)
            {
                Write(message);
            }
            if (m_nextLogger != null)
            {
                m_nextLogger.LogMessage(level, message);
            }
        }
        abstract protected void Write(string message);
    }

    public class ConsoleLogger:Logger
    {
        public ConsoleLogger(LogLevel level)
        {
            m_logLevel = level;
        }

        override protected void Write(string message)
        {
            Console.WriteLine($"Console Logger => {message}");
        }
    }

    public class FileLogger : Logger
    {
        public FileLogger(LogLevel level)
        {
            m_logLevel = level;
        }

        override protected void Write(string message)
        {
            Console.WriteLine($"File Logger -> {message}");
        }
    }

    public class ErrorLogger : Logger
    {
        public ErrorLogger(LogLevel level)
        {
            m_logLevel = level;
        }

        override protected void Write(string message)
        {
            Console.WriteLine($"Error Logger >> {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleLogger(LogLevel.INFO);
            var file = new FileLogger(LogLevel.DEBUG);
            var error = new ErrorLogger(LogLevel.ERROR);
            console.SetNextLogger(file);
            file.SetNextLogger(error);

            console.LogMessage(LogLevel.INFO, "Test info");
            console.LogMessage(LogLevel.DEBUG, "Test debug");
            console.LogMessage(LogLevel.ERROR, "Test error");

            Console.ReadKey();
        }
    }
}
