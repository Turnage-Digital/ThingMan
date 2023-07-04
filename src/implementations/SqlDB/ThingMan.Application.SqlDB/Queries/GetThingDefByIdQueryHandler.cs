using ThingMan.Application.Queries;
using ThingMan.Core;
using ThingMan.Core.SqlDB.Views;

namespace ThingMan.Application.SqlDB.Queries;

public class GetThingDefByIdQueryHandler : GetThingDefByIdQueryHandler<ThingDefView>
{
    public GetThingDefByIdQueryHandler(
        IGetReadOnlyThingDefById<ThingDefView> getReadOnlyThingDefById
    ) : base(getReadOnlyThingDefById) { }
}