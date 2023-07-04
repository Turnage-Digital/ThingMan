using MediatR;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEvent : INotification
{
    public string Id { get; set; } = null!;
}