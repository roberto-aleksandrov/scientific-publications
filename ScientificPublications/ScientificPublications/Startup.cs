using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScientificPublications.Application.Infrastructure;
using ScientificPublications.Application.Interfaces;
using ScientificPublications.Application.Users.Commands.CreateUser;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Infrastructure;
using ScientificPublications.Infrastructure.Data;
using ScientificPublications.WebUI.Filters;
using System.Reflection;

namespace ScientificPublications.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<ScientificPublicationsContext>(c =>
               c.UseSqlServer(Configuration.GetConnectionString("ScientificPublicationsConnection")));
        }

        private void RegisterMediatr(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            RegisterDbContext(services);
            RegisterMediatr(services);

            services.AddTransient<IAsyncRepository<User>, EfRepository<User>>();
            services.AddTransient<IRepository<User>, EfRepository<User>>();
            services.AddTransient<IData, ScientificPublicationsData>();
            
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
