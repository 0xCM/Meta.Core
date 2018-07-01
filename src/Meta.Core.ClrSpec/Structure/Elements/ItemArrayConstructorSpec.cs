//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static metacore;

public static partial class ClrStructureSpec
{
    public class ItemArrayConstructorSpec : ConstructorSpec
    {
        public ItemArrayConstructorSpec(ClrClassName DeclaringTypeName, 
            IReadOnlyList<PropertySpec> InitializedMembers, 
            ClrAccessKind? AccessLevel = null)
            : base
            (
                  DeclaringTypeName,
                  AccessLevel,
                  MethodParameters: rolist(new MethodParameterSpec("items", 
                      ClrCollectionClosure.Array(new ClrClassName("object"))))
            )
        {
            this.InitializedMembers = InitializedMembers;
        }

        public IReadOnlyList<PropertySpec> InitializedMembers { get; }
    }
}