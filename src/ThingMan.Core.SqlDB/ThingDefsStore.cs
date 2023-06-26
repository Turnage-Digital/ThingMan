using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.ValueObjects;

namespace ThingMan.Core.SqlDB;

internal class ThingDefsStore : IThingDefsStore<IWritableThingDef>
{
    private readonly ThingManDbContext _dbContext;
    private readonly EntityStore<ThingDefEntity> _entityStore;

    public ThingDefsStore(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
        _entityStore = new EntityStore<ThingDefEntity>(dbContext);
    }

    public Task<IWritableThingDef> InitAsync(CancellationToken cancellationToken = default)
    {
        var retval = new ThingDefEntity();
        return Task.FromResult((IWritableThingDef)retval);
    }

    public async Task CreateAsync(IWritableThingDef entity, CancellationToken cancellationToken = default)
    {
        await _entityStore.CreateAsync((ThingDefEntity)entity, cancellationToken);
    }

    public async Task<IWritableThingDef?> ReadAsync(string id, CancellationToken cancellationToken = default)
    {
        var retval = await _entityStore.ReadAsync(id, cancellationToken);
        return retval;
    }

    public Task SetNameAsync(IWritableThingDef thingDef, string name, CancellationToken cancellationToken)
    {
        ((ThingDefEntity)thingDef).Name = name;
        return Task.CompletedTask;
    }

    public Task<string> GetNameAsync(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var retval = ((ThingDefEntity)thingDef).Name;
        return Task.FromResult(retval);
    }

    public Task SetStatusDefsAsync(
        IWritableThingDef thingDef,
        StatusDef[] statusDefs,
        CancellationToken cancellationToken
    )
    {
        ((ThingDefEntity)thingDef).StatusDefs = statusDefs
            .Select(sd => new StatusDefEntity { Name = sd.Name, })
            .ToList();
        return Task.CompletedTask;
    }

    public Task<StatusDef[]> GetStatusDefsAsync(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var retval = ((ThingDefEntity)thingDef).StatusDefs
            .Select(x => new StatusDef { Name = x.Name })
            .ToArray();
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef1Async(
        IWritableThingDef thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            ((ThingDefEntity)thingDef).PropertyDef1 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            ((ThingDefEntity)thingDef).PropertyDef1 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef1Async(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var prop = ((ThingDefEntity)thingDef).PropertyDef1;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef2Async(
        IWritableThingDef thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            ((ThingDefEntity)thingDef).PropertyDef2 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            ((ThingDefEntity)thingDef).PropertyDef2 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef2Async(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var prop = ((ThingDefEntity)thingDef).PropertyDef2;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef3Async(
        IWritableThingDef thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            ((ThingDefEntity)thingDef).PropertyDef3 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            ((ThingDefEntity)thingDef).PropertyDef3 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef3Async(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var prop = ((ThingDefEntity)thingDef).PropertyDef3;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef4Async(
        IWritableThingDef thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            ((ThingDefEntity)thingDef).PropertyDef4 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            ((ThingDefEntity)thingDef).PropertyDef4 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef4Async(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var prop = ((ThingDefEntity)thingDef).PropertyDef4;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef5Async(
        IWritableThingDef thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            ((ThingDefEntity)thingDef).PropertyDef5 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            ((ThingDefEntity)thingDef).PropertyDef5 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef5Async(IWritableThingDef thingDef, CancellationToken cancellationToken)
    {
        var prop = ((ThingDefEntity)thingDef).PropertyDef5;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }
}