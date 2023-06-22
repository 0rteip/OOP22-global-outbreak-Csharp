using OP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

namespace OOP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

/// <summary>
/// Logger.
/// </summary>
public class Logger
{
    /// <summary>
    /// Write a log message, LoglevelI Info.
    /// </summary>
    /// <param name="message"></param>
    public static void Log(string message)
    {
        Log(LogLevel.Info, message);
    }

    /// <summary>
    /// Specific LogLevel and message.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="message"></param>
    public static void Log(LogLevel level, string message)
    {
        string logEntry = $"{DateTime.Now} [{level}] {message}";
        Console.WriteLine(logEntry);
    }
}
