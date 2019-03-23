﻿namespace Clarity.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Serilog;
    using Serilog.Events;
    using Serilog.Formatting.Elasticsearch;
    using Serilog.Sinks.Elasticsearch;

    public class Program
    {
        // https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/#update-main-method-in-programcs
        public static async Task Main(string[] args)
        {
            using (var tokenSource = new CancellationTokenSource())
            {
                var webHost = BuildWebHost(args);
                await webHost.MigrateDatabaseAsync(tokenSource.Token);
                await webHost.RunAsync(tokenSource.Token);
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configBuilder => configBuilder.AddAzureKeyVault())
                .UseStartup<Startup>()
                .UseSerilog((context, loggerConfiguration) => loggerConfiguration
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.ApplicationInsights(
                        telemetryConfiguration: TelemetryConfiguration.Active,
                        telemetryConverter: TelemetryConverter.Traces)
                    .WriteTo.File(
                        path: "D:\\home\\LogFiles\\Application\\Clarity.Api.txt",
                        fileSizeLimitBytes: 1_000_000,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1),
                        rollOnFileSizeLimit: true)
                    .WriteTo.Elasticsearch(
                        options: new ElasticsearchSinkOptions(new Uri("https://52.247.198.17:9200"))
                        {
                            AutoRegisterTemplate = true,
                            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                            IndexFormat = "Clarity.Api-logs-index",
                            CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                            ModifyConnectionSettings = x => x
                                .BasicAuthentication(
                                    userName: "elastic",
                                    password: "kGRKd8x9Yw1FQm%O")
                        }))
                .Build();
    }
}
