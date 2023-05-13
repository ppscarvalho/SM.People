#nullable disable

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.MQ.Configuration;
using SM.MQ.Extensions;
using SM.MQ.Models;
using SM.People.Core.Application.AutoMappings;
using SM.People.Core.Application.Commands.Supplier;
using SM.People.Core.Application.Consumers;
using SM.People.Core.Application.Handlers;
using SM.People.Core.Application.Models;
using SM.People.Core.Application.Queries.Supplier;
using SM.Resource.Communication.Mediator;
using SM.Resource.Util;
using System.Reflection;
using IPublisher = SM.MQ.Configuration.IPublisher;

namespace SM.People.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapping
            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()), typeof(object));

            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Query
            services.AddScoped<IRequestHandler<GetSupplierByIdQuery, SupplierModel>, SupplierQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllSupplierQuery, IEnumerable<SupplierModel>>, SupplierQueryHandler>();

            // Command
            services.AddScoped<IRequestHandler<AddSupplierCommand, DefaultResult>, SupplierCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSupplierCommand, DefaultResult>, SupplierCommandHandler>();

            // RabbitMQ
            services.AddRabbitMq(configuration);
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new BuilderBus(configuration["RabbitMq:ConnectionString"])
            {
                Consumers = new HashSet<Consumer>
                {
                    new Consumer(
                        queue: configuration["RabbitMq:ConsumerSupplier"],
                        typeConsumer: typeof(RPCConsumerSupplier),
                        quorumQueue: true
                    )
                },

                Publishers = new HashSet<IPublisher>
                {
                    new Publisher<RequestIn>(queue: configuration["RabbitMq:ConsumerSupplier"])
                },

                Retry = new Retry(retryCount: 3, interval: TimeSpan.FromSeconds(60))
            };
            services.AddEventBus(builder);
        }
    }
}
