using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ToAC3;

namespace ToAC3Converter
{
    internal static class Program
    {
        private static void ConfigureServices(IServiceCollection services)
        {
            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Async(configuration =>
                {
                    configuration.File("logs.txt");
                })
                .CreateLogger();

            services.AddLogging(builder =>
            {
                builder.AddSerilog(loggerConfiguration);
            });

            services.AddSingleton<MainForm>();
            services.AddSingleton<AudioStreams>();
        }

        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                Application.Run(serviceProvider.GetRequiredService<MainForm>());
            }
        }
    }
}
