//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using static minicore;

using N = SystemNode;

using Meta.Core;

class ServiceRealization : IEquatable<ServiceRealization>
{
    public static ServiceRealization Define(Type RealizingType, Type ContractType)
        => new ServiceRealization(RealizingType, ContractType);

    public ServiceRealization(Type RealizingType, Type ContractType)
    {
        this.ContractType = ContractType;
        this.RealizingType = RealizingType;
    }

    public Type ContractType { get; }

    public Type RealizingType { get; }

    public bool Equals(ServiceRealization other)
        => other is null ? false
            : ContractType == other.ContractType &&
                RealizingType == other.RealizingType;

    public override int GetHashCode()
        => ContractType.GetHashCode()
        ^ RealizingType.GetHashCode();

    public override bool Equals(object obj)
        => Equals(obj as ServiceRealization);

    public override string ToString()
        => $"{RealizingType.Name}-->{ContractType.Name}";
}
