using SM.Resource.Communication.Mediator;
using SM.Resource.Domain;
using SM.People.Infrastructure.DbContexts;

namespace SM.People.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishEvent(this IMediatorHandler mediator, PeopleDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvent());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
