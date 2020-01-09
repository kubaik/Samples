using System;
using System.IO;
using Serilog;

namespace SerilogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>> Serilog Demo <<<");

            Log.Logger = new LoggerConfiguration().CreateLogger();
            Log.Information("Nenhuma saída de log!");
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine("Logs", "log-.txt"), 
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information("Multiplas saídas!");
        }
    }
}