using ThingMan.Core.Entities;
using ThingMan.Domain.Events;

namespace ThingMan.Domain;

public class ThingDefAggregate : ThingDef, IAggregate
{
    public static ThingDefAggregate Create(
        string name,
        string userId,
        ICollection<StatusDef> statusDefs,
        ICollection<NotificationDef> notificationDefs,
        PropertyDef? propertyDef1 = null,
        PropertyDef? propertyDef2 = null,
        PropertyDef? propertyDef3 = null,
        PropertyDef? propertyDef4 = null,
        PropertyDef? propertyDef5 = null
    )
    {
        var retval = new ThingDefAggregate
        {
            Name = name,
            UserId = userId,
            StatusDefs = statusDefs,
            NotificationDefs = notificationDefs,
            PropertyDef1 = propertyDef1,
            PropertyDef2 = propertyDef2,
            PropertyDef3 = propertyDef3,
            PropertyDef4 = propertyDef4,
            PropertyDef5 = propertyDef5
        };

        retval.AddEvent(new ThingDefCreatedEvent { ThingDefAggregate = retval });

        return retval;
    }
}