using System;
using FinApp.Domain.Expenses.Services;
using FinApp.Infrastructure.Expenses.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FinApp.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection RegisterInfrasturcureDependencies(this IServiceCollection services) =>
            services.AddScoped<IExpenseRepository, ExpenseRepository>().AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddDbContext<ExpensesDbContext>(options =>
                    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FinApp;Trusted_Connection=True;"));
        //todo: to appSettings.json Development only

        public static IHost RunMigrations(this IHost host)
        {
            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<ExpensesDbContext>();
                    // for demo purposes, delete the database & migrate on startup so 
                    // we can start with a clean slate
                    if (context != null)
                    {
                        context.Database.EnsureDeleted();
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            return host;
            // run the web app
        }
    }
}
