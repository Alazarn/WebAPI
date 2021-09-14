using Contracts;
using LoggerService;
using Entities;
using Repository;
using WebAPI.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDbContext>(opts => {
                opts.UseSqlServer(configuration["ConnectionStrings:ProductConnection"], 
                    b => b.MigrationsAssembly("WebAPI"));
            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services) {

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateProductExistsAttribute>();
            services.AddScoped<ValidateRequirementsForProductExistsAttribute>();
        }

        //public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder)
        //{
        //   return builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
        //}

    }
}

