using System;
using System.Text.Json.Serialization;
using FinApp.Api.DbContexts;
using FinApp.Api.Helpers.Sorting.PropertyMappings;
using FinApp.Api.Models;
using FinApp.Api.Services;
using FinApp.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace FinApp
{
    public class Startup
    {
        private const string DefaultCorsPolicy = "Internal";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                }).AddNewtonsoftJson(setup =>
                {
                    setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPropertyMappingService, MappingSelector>();
            services.AddTransient<IPropertyMaping, ExpensePropertyMapping>();

            services.AddCors(opt => opt.AddPolicy(DefaultCorsPolicy,
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            services.AddDbContext<ExpensesDbContext>(options =>
                options.UseSqlServer(@"
  Server=host.docker.internal,1433;
  Database=FinApp;
  User=sa;
  Password=RoR9148C"));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "FinApp", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinApp v1"));
            }

            app.UseCors(DefaultCorsPolicy);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}