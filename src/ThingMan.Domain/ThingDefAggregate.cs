using MediatR;
using ThingMan.Core;
using ThingMan.Core.ValueObjects;

namespace ThingMan.Domain;

public class ThingDefAggregate<TThingDef>
    where TThingDef : IWritableThingDef
{
    private readonly IMediator _mediator;
    private readonly IThingDefsStore<TThingDef> _store;
    private readonly IUserContext _userContext;

    public ThingDefAggregate(IThingDefsStore<TThingDef> store, IMediator mediator, IUserContext userContext)
    {
        _store = store;
        _mediator = mediator;
        _userContext = userContext;
    }

    public async Task<TThingDef> CreateAsync(
        string name,
        StatusDef[] statusDefs,
        PropertyDef? propertyDef1 = null,
        PropertyDef? propertyDef2 = null,
        PropertyDef? propertyDef3 = null,
        PropertyDef? propertyDef4 = null,
        PropertyDef? propertyDef5 = null,
        CancellationToken cancellationToken = default
    )
    {
        var retval = await _store.InitAsync(cancellationToken);
        
        await _store.SetNameAsync(retval, name, cancellationToken);
        await _store.SetStatusDefsAsync(retval, statusDefs, cancellationToken);
        await _store.SetPropertyDef1Async(retval, propertyDef1, cancellationToken);
        await _store.SetPropertyDef2Async(retval, propertyDef2, cancellationToken);
        await _store.SetPropertyDef3Async(retval, propertyDef3, cancellationToken);
        await _store.SetPropertyDef4Async(retval, propertyDef4, cancellationToken);
        await _store.SetPropertyDef5Async(retval, propertyDef5, cancellationToken);

        // setters

        await _store.CreateAsync(retval, cancellationToken);

        // events

        return retval;
    }
}