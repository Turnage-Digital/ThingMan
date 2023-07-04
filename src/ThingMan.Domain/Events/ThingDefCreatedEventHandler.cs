using MediatR;
using Serilog;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEventHandler : INotificationHandler<ThingDefCreatedEvent>
{
    public Task Handle(ThingDefCreatedEvent notification, CancellationToken cancellationToken = default)
    {
        Log.Information("ThingDefCreatedEvent: {Id}", notification.Id);
        return Task.CompletedTask;
    }
}