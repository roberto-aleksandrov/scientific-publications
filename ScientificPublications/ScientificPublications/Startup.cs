using AutoMapper;
using Calendar.Utilities.TokenGenerators;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ScientificPublications.Application.AutoMapper;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Interfaces.Authentication;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Application.Middlewares;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Infrastructure;
using ScientificPublications.Infrastructure.Data;
using ScientificPublications.Infrastructure.Interfaces.PasswordGenerators;
using ScientificPublications.Infrastructure.PasswordGenerators;
using ScientificPublications.WebUI.AutoMapper.Profiles;
using ScientificPublications.WebUI.Filters;
using ScientificPublications.WebUI.Models.Common;
using ScientificPublications.WebUI.Models.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.Text;

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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(RegisterUserCommandHandler).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(BmToRequestProfile).GetTypeInfo().Assembly, typeof(EntityToDtoProfile).GetTypeInfo().Assembly });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                options.Filters.Add(new TypeFilterAttribute(typeof(AuthenticationFilter)));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterUserCommandValidator>());

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            RegisterDbContext(services);
            RegisterMediatr(services);

            services.AddOptions();
            services.AddTransient<IAsyncRepository<PublicationEntity>, EfRepository<PublicationEntity>>();
            services.AddTransient<IAsyncRepository<UserEntity>, EfRepository<UserEntity>>();
            services.AddTransient<IAsyncRepository<AuthorEntity>, EfRepository<AuthorEntity>>();
            services.AddTransient<IAsyncRepository<CathedralAuthorEntity>, EfRepository<CathedralAuthorEntity>>();
            services.AddTransient<IAsyncRepository<NonCathedralAuthorEntity>, EfRepository<NonCathedralAuthorEntity>>();
            services.AddTransient<IData, ScientificPublicationsData>();
            services.AddTransient<IHasher, PasswordGenerator>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();

            services.AddSingleton<IPasswordGeneratorOptions>(Configuration.GetSection("Auth").Get<PasswordGeneratorOptions>());
            services.AddSingleton<IAuthenticationOptions>(Configuration.GetSection("Auth").Get<AuthenticationOptions>());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration.GetSection("Auth:Iss").Value,
                        ValidAudience = Configuration.GetSection("Auth:Audience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Auth:SecretKey").Value))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

        }
    }
}
