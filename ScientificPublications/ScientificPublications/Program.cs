using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScientificPublications.Application.Common.Models.Requests;
using ScientificPublications.Infrastructure;
using ScientificPublications.Infrastructure.Scopus;
using ScientificPublications.Persistance;
using ScientificPublications.WebUI.Models.Options;
using System;

namespace ScientificPublications.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //testc();
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<ScientificPublicationsContext>();
                    context.Database.EnsureCreated();
                    ScientificPublicationsInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while initializing the database.");
                }
            }

            host.Run();
        }

        private static void testc()
        {
            var api = new ScopusApi(new ScopusApiOptions { ApiKey = "87c9349e10f8225b09815fd8a8b29833", Url = "http://api.elsevier.com/" });
            var x = api.GetAuthorPublications(new GetAuthorPublicationsRequest { AuthorScopusId = "6602078125" }).Result;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
