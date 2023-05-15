using MediatR;
using Serilog;

namespace ThingMan.Domain.Events;

internal class ThingDefCreatedEventHandler : INotificationHandler<ThingDefCreatedEvent>
{
    public Task Handle(ThingDefCreatedEvent notification, CancellationToken cancellationToken)
    {
        Log.Information("Received event: {Event}", nameof(notification));
        return Task.CompletedTask;
    }
}