using AutoMapper;
using Demo.HR.Contracts.Repositories;
using Demo.HR.Contracts.Services;
using Demo.HR.Models.Db;
using Demo.HR.Repositories;
using Demo.HR.Services;
using Demo.HR.Services.DtoValidators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;

namespace Demo.HR.API.Bootstrapper
{
    public static class Bootstrap
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;

        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            services.AddCors();
            services.AddMvc()

                // Locate and add all validators from the containing assembly of FilterDtoValidator
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FilterDtoValidator>())
                .AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            BoostrapServices();
            BootstrapRepositories();

            BootstrapNSwag();
            BootstrapAutoMapper();
            BootstrapCustomBadRequest();
        }

        private static void BootstrapNSwag()
        {
            // Register the Swagger services
            _services.AddSwaggerDocument(config =>
            {
                // Post process the generated document
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Demo HR API";
                    document.Info.Description = string.Empty;
                    document.Info.TermsOfService = "None";
                };

                config.TypeMappers.Add(new PrimitiveTypeMapper(typeof(FileContentResult), s => s.Type = JsonObjectType.File));
            });
        }

        private static void BootstrapAutoMapper()
        {
            _services.AddAutoMapper(typeof(DefaultMappings));
        }

        private static void BoostrapServices()
        {
            _services.AddScoped<IAllocationService, AllocationService>();
        }

        private static void BootstrapRepositories()
        {
            _services
                // .AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(options =>
                            options
                                .UseSqlite("Data Source=DemoHR.db"));

                                // .UseSqlServer(
                                //    _configuration.GetConnectionString("App"),
                                //    providerOptions => providerOptions.EnableRetryOnFailure())
                                // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            _services.AddScoped<IAllocationRepository, AllocationRepository>();
        }

        private static void BootstrapCustomBadRequest()
        {
            _services.Configure<ApiBehaviorOptions>(a =>
            {
                a.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new CustomBadRequest(context);

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }
    }
}