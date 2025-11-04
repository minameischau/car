using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace CaraCara.Infrastructure.Logging;

public static class SerilogExtensions
{
    public static IHostBuilder UseAppSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, services, configuration) =>
        {
            // 🔹 Load cấu hình Serilog từ file JSON trong SharedSetting
            var logConfig = LoadSharedLogConfiguration(context.HostingEnvironment);

            if (logConfig != null)
            {
                configuration.ReadFrom.Configuration(logConfig);
            }
            else
            {
                Console.WriteLine("⚠️ Không tìm thấy file cấu hình log trong SharedSetting.");
            }

            configuration
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application: ", context.HostingEnvironment.ApplicationName)
                .Enrich.WithProperty("Environment: ", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("MachineName: ", Environment.MachineName)
                .WriteTo.Console();
        });

        return hostBuilder;
    }

    /// <summary>
    /// Tìm và load file log.{Environment}.json từ Cara.SharedSetting (đã được copy khi build).
    /// </summary>
    private static IConfigurationRoot? LoadSharedLogConfiguration(IHostEnvironment env)
    {
        try
        {
            // 📂 File được copy khi build: log.Development.json, log.Production.json, ...
            var sharedLogFilePath = Path.Combine(AppContext.BaseDirectory, $"logs.{env.EnvironmentName}.json");

            if (!File.Exists(sharedLogFilePath))
            {
                Console.WriteLine($"⚠️ File log config không tồn tại: {sharedLogFilePath}");
                return null;
            }

            Console.WriteLine($"✅ Đang load file log config: {sharedLogFilePath}.");

            var config = new ConfigurationBuilder()
                .AddJsonFile(sharedLogFilePath, optional: false, reloadOnChange: true)
                .Build();

            return config;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Lỗi khi load file log config: {ex.Message}");
            return null;
        }
    }
}