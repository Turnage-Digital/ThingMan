using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.ValueObjects;

namespace ThingMan.Core.SqlDB;

internal class ThingDefsStore : IThingDefsStore<ThingDefEntity>
{
    private readonly ThingManDbContext _dbContext;
    private readonly EntityStore<ThingDefEntity> _entityStore;

    public ThingDefsStore(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
        _entityStore = new EntityStore<ThingDefEntity>(dbContext);
    }

    public Task<ThingDefEntity> InitAsync(CancellationToken cancellationToken = default)
    {
        var retval = new ThingDefEntity();
        return Task.FromResult(retval);
    }

    public async Task CreateAsync(ThingDefEntity entity, CancellationToken cancellationToken = default)
    {
        await _entityStore.CreateAsync(entity, cancellationToken);
    }

    public async Task<ThingDefEntity?> ReadAsync(string id, CancellationToken cancellationToken = default)
    {
        var retval = await _entityStore.ReadAsync(id, cancellationToken);
        return retval;
    }

    public Task SetNameAsync(ThingDefEntity thingDef, string name, CancellationToken cancellationToken)
    {
        thingDef.Name = name;
        return Task.CompletedTask;
    }

    public Task<string> GetNameAsync(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var retval = thingDef.Name;
        return Task.FromResult(retval);
    }

    public Task SetStatusDefsAsync(ThingDefEntity thingDef, StatusDef[] statusDefs, CancellationToken cancellationToken)
    {
        thingDef.StatusDefs = statusDefs
            .Select(sd => new StatusDefEntity { Name = sd.Name })
            .ToList();
        return Task.CompletedTask;
    }

    public Task<StatusDef[]> GetStatusDefsAsync(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var retval = thingDef.StatusDefs
            .Select(x => new StatusDef { Name = x.Name })
            .ToArray();
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef1Async(
        ThingDefEntity thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            thingDef.PropertyDef1 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            thingDef.PropertyDef1 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef1Async(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var prop = thingDef.PropertyDef1;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef2Async(
        ThingDefEntity thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            thingDef.PropertyDef2 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            thingDef.PropertyDef2 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef2Async(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var prop = thingDef.PropertyDef2;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef3Async(
        ThingDefEntity thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            thingDef.PropertyDef3 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            thingDef.PropertyDef3 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef3Async(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var prop = thingDef.PropertyDef3;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef4Async(
        ThingDefEntity thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            thingDef.PropertyDef4 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            thingDef.PropertyDef4 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef4Async(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var prop = thingDef.PropertyDef4;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }

    public Task SetPropertyDef5Async(
        ThingDefEntity thingDef,
        PropertyDef? propertyDef,
        CancellationToken cancellationToken
    )
    {
        if (propertyDef is not null)
        {
            thingDef.PropertyDef5 = new PropertyDefEntity
            {
                Name = propertyDef.Name,
                Type = propertyDef.PropertyType
            };
        }
        else
        {
            thingDef.PropertyDef5 = null;
        }

        return Task.CompletedTask;
    }

    public Task<PropertyDef?> GetPropertyDef5Async(ThingDefEntity thingDef, CancellationToken cancellationToken)
    {
        var prop = thingDef.PropertyDef5;
        var retval = prop is not null ? new PropertyDef { Name = prop.Name, PropertyType = prop.Type } : null;
        return Task.FromResult(retval);
    }
}