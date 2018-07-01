//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


public class ClrInterfaceDescription : ClrTypeDescription<ClrInterfaceDescription, ClrInterface>
{
    public static ClrInterfaceDescription Create<I>()
        => new ClrInterfaceDescription(ClrInterface.Get<I>());

    IReadOnlyDictionary<string, ClrMethodDescription> OperationIndex;

    ClrInterfaceDescription(ClrInterface Interface)
        : base(Interface)
    {
        this.OperationIndex = Interface.DeclaredOperations.ToDictionary(x => x.Name,
            x => new ClrMethodDescription(x.ReflectedElement));
    }


    public Option<ClrMethodDescription> DescribeOperation(string name)
        => OperationIndex.TryFind(name);

    public ClrInterface Interface
        => DescribedElement;

}
