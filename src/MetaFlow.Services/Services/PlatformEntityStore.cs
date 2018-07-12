//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using MetaFlow.Core.Storage;

    using static metacore;
    
    class PlatformEntityStore :  PlatformService<PlatformEntityStore, IEntityStore>, IEntityStore
    {        
        public PlatformEntityStore(INodeContext C)
            : base(C){}

        Option<T> TryReconsitute<T>(Json J)
            => Try(() => Serializer.ObjectFromJson<T>(J));

        Option<Json> TrySerialize<T>(T Entity)
            => Try(() => Serializer.ObjectToJson(Entity));

        Option<IReadOnlyList<Core.PlatformEntity>> Lookup(SystemUri id)
            => HostPlatformBroker.Get(new FindPlatformEntity(id));

        Option<SystemUri> Persist(SystemUri id, SystemUri TypeUri, Json J)
            => from saved in HostPlatformBroker.Call(new StorePlatformEntity(id, TypeUri, J)).ToOption()
               select id;

        public Option<T> FindEntity<T>(SystemUri id)
            => from e in Lookup(ifNull(id, () => typeof(T).Uri()))
               from x in e.TryGetSingle()
               from r in TryReconsitute<T>(x.Body)
               select r;

        public Option<SystemUri> SaveEntity<T>(T Body, SystemUri id)
            => from j in TrySerialize(Body)
               from s in Persist(ifNull(id, () => typeof(T).Uri()), typeof(T).Uri(), j)
               select s;                           
    }
}