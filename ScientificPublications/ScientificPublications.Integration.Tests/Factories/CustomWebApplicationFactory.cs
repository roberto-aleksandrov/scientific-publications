using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScientificPublications.Application.Common.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Infrastructure;
using ScientificPublications.Infrastructure.PasswordGenerators;
using ScientificPublications.Infrastructure.PasswordGenerators.Interfaces;
using ScientificPublications.Integration.Tests.Seed;
using ScientificPublications.Integration.Tests.Seed.Hooks;
using ScientificPublications.WebUI.Models.Common;
using System;

namespace ScientificPublications.Integration.Tests.Factories
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private IServiceScope _serviceScope;

        public ScientificPublicationsContext Context { get; private set; }

        public ScientificPublicationsSeeder Seeder { get; private set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _serviceScope.Dispose();
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
                services.AddSingleton<ScientificPublicationsSeeder>();
                services.AddSingleton<IPreSeedHook<UserEntity>, UserHook>();
                services.AddSingleton<PreSeedHooks>();

                _serviceScope = services.BuildServiceProvider().CreateScope();
                var scopedServices = _serviceScope.ServiceProvider;

                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                Context = scopedServices.GetRequiredService<ScientificPublicationsContext>();
                Seeder = scopedServices.GetRequiredService<ScientificPublicationsSeeder>();

                Context.Database.EnsureCreated();

                try
                {
                    ScientificPublicationsSeedTest.Seed(Context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                }


                var authors = Context.Authors.ToListAsync().Result;
            });
        }
    }
}
