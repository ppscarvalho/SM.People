#nullable disable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.People.Core.Application.Extensions;
using SM.People.Core.Application.Interfaces.Repositories.Domain;
using SM.People.Infrastructure.DbContexts;
using SM.People.Infrastructure.Repositories;
using SM.Resource.Data;
using SM.Resource.Messagens.CommonMessage.Notifications;

namespace SM.People.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationLayer(configuration);
            services.AddDatabasePersistence(configuration);

            // Repositories
            services.AddRepositories();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Context
            services.AddScoped<PeopleDbContext>();
            services.AddScoped<IUnitOfWork, PeopleDbContext>();
        }

        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PeopleDbContext>(options =>
                options.UseMySQL(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)
                ),
                ServiceLifetime.Scoped);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISupplierRepository, SupplierRepository>();
        }
    }
}
