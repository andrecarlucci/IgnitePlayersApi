using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;

namespace PlayersApi.BadgesService {
    public class Program {
        public static void Main(string[] args) {
            var elasticSearchUrl = "http://localhost:9200";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Service", "Badges")
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchUrl)) {
                    AutoRegisterTemplate = true,
                    InlineFields = true
                })
                .CreateLogger();

            Log.Logger.Information("Badges Service Started");

            try {
                CreateWebHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception ex) {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
