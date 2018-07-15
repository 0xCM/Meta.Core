//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;


using Meta.Core;

using static metacore;

class JsonEntityStore : ApplicationComponent, IEntityStore
{
    public JsonEntityStore(IApplicationContext C)
        : base(C){ }

    Option<T> TryReconsitute<T>(Json J)
        => Try(() => JsonServices.ToObject<T>(J));

    Option<Json> TrySerialize<T>(T Entity)
        => Try(() => JsonServices.ToJson(Entity));

    Option<JsonEntity> Lookup(SystemUri id)
        => from text in id.ToLocalPath().TryReadAllText()
           let json = Json.FromText(text)
           from recon in TryReconsitute<JsonEntity>(json)
           select recon;

    Option<SystemUri> Persist(SystemUri id, SystemUri type, Json json)
        => from saved in id.ToLocalPath().TryWriteAllText(json)
           select id;

    public Option<T> FindEntity<T>(SystemUri id)
        => from e in Lookup(ifNull(id, () => typeof(T).Uri()))
           from r in TryReconsitute<T>(e.Body)
           select r;
            
    public Option<SystemUri> SaveEntity<T>(T Body, SystemUri id)
        => from j in TrySerialize(Body)
            from s in Persist(ifNull(id, () => typeof(T).Uri()), typeof(T).Uri(), j)
            select s;
}
