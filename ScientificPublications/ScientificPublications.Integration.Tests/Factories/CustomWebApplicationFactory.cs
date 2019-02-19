using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Infrastructure;
using ScientificPublications.Infrastructure.Interfaces.PasswordGenerators;
using ScientificPublications.Infrastructure.PasswordGenerators;
using ScientificPublications.Integration.Tests.Seed;
using ScientificPublications.WebUI.Models.Common;
using System;

namespace ScientificPublications.Integration.Tests.Factories
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ScientificPublicationsContext Context { get; private set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Context?.Dispose();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<ScientificPublicationsContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddTransient<IHasher, PasswordGenerator>();

                services.AddSingleton<IPasswordGeneratorOptions>(configuration.GetSection("Auth").Get<PasswordGeneratorOptions>());

                Context = services.BuildServiceProvider().GetRequiredService<ScientificPublicationsContext>();

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var hasher = scopedServices.GetRequiredService<IHasher>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    Context.Database.EnsureCreated();

                    try
                    {
                        ScientificPublicationsSeedTest.Seed(Context, hasher);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
                var authors = Context.Authors.ToListAsync().Result;
            });
        }
    }
}
