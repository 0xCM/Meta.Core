//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using static metacore;

    public class SystemOperationIndex : IEnumerable<SystemOperation>
    {
        IReadOnlyDictionary<SystemIdentifier, ReadOnlySet<SystemOperation>> Data { get; }
            
        public SystemOperationIndex(IReadOnlyDictionary<SystemIdentifier, ReadOnlySet<SystemOperation>> Data)
        {
            this.Data = Data;
        }

        public IEnumerable<SystemOperation> SystemOperations(SystemIdentifier SystemId)
            => Data.ContainsKey(SystemId) 
            ? Data[SystemId] 
            : stream<SystemOperation>();

        public Option<SystemOperation> SystemOperation(SystemIdentifier SystemId, string HostType, string LocalName)
            => SystemOperations(SystemId).Where(op => op.HostTypeName == HostType && op.LocalName == LocalName).TryGetSingle();


        public IEnumerable<SystemOperation> this[SystemIdentifier SystemId]
            => SystemOperations(SystemId);


        IEnumerator<SystemOperation> IEnumerable<SystemOperation>.GetEnumerator()
            => Data.Values.SelectMany(x => x).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Data.Values.SelectMany(x => x).GetEnumerator();
    }
}
