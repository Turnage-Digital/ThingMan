using MediatR;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEvent<TKey> : INotification
{
    public TKey Id { get; set; } = default!;
}