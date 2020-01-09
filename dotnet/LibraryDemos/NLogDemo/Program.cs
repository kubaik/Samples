using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace NLogDemo
{
    class Program
    {
        private static ServiceProvider _provider;

        static void Main(string[] args)
        {
            Console.WriteLine(">> NLog Demo <<<");

            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddNLog("NLog.config");
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });
            _provider = services.BuildServiceProvider();

            Log("Pessoa native NLog", true);
            Log("Nota bridge by Microsoft Logging", false);
        }

        private static void Log(string info, bool nativeNlog)
        {
            if (nativeNlog)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Trace("{0} -> Iniciando processo", info);
                logger.Warn("{0} -> Atenção neste procedimento", info);
                logger.Info("{0} -> Procedimento informativo", info);
                logger.Error(CreateException(), $"{info} -> Erro no procedimento", info);
                logger.Fatal(CreateException(), $"{info} -> Erro fatal no procedimento", info);
                
                LogManager.GetLogger("raw").Info("-- End of NLOG");
                LogManager.GetLogger("raw").Info("");
            }
            else
            {
                using var scope = _provider.CreateScope();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                var factory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                
                logger.LogTrace("{0} -> Iniciando processo", info);
                logger.LogWarning("{0} -> Atenção neste procedimento", info);
                logger.LogInformation("{0} -> Procedimento informativo", info);
                logger.LogError(CreateException(), $"{info} -> Erro no procedimento", info);
                logger.LogCritical(CreateException(), $"{info} -> Erro fatal no procedimento", info);

                factory.CreateLogger("raw").LogInformation("-- End of MS");
                factory.CreateLogger("raw").LogInformation("");
            }
        }

        private static Exception CreateException()
        {
            try
            {
                int.Parse("abc");
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        } 
    }
}