using ThingMan.Core;

namespace ThingMan.Domain;

public interface IThingDefsRepository :
    IRead<ThingDef>, ICreate<ThingDef> { }