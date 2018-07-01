//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{
    public class PropertyConstructorSpec : ConstructorSpec
    {
        public readonly IReadOnlyList<PropertySpec> InitializedMembers;

        public PropertyConstructorSpec(ClrClassName DeclaringTypeName,
            IReadOnlyList<PropertySpec> InitializedMembers, ClrAccessKind? AccessLevel = null)
            : base
            (
                  DeclaringTypeName,
                  AccessLevel,
                  MethodParameters:
                    mapi(InitializedMembers, (i, p)
                        => new MethodParameterSpec(new ClrMethodParameterName(p.Name.SimpleName), p.PropertyType, i)
                    ).ToArray()
            )
        {
            this.InitializedMembers = InitializedMembers;
        }
    }
}