using BS.Infrastructure;
using BS.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarAccessGate.Extension
{
    public static class ConfigurationExtension
    {

        //add swagger Config
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CarAccessGateAPI",
                    Description = "Car Access Gate API"
                });
            });
        }
        public static void UseCustomSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarAccessGate");
                c.RoutePrefix = string.Empty;
            });
        }

        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }


        public static void AddDIConfig(this IServiceCollection services)
        {

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICarService, ExitCarService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IAccessCardRepository, AccessCardRepository>();
            services.AddScoped<IAccessCardCreditRepository, AccessCardCreditRepository>();
            services.AddScoped<IExitGateRepository,ExitGateRepository>() ;
        }

            public static void AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BSContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("AppConnection")));
        }
        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
