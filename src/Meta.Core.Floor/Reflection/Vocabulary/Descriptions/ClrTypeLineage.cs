//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static metacore;

/// <summary>
/// Reifies a type lineage in the form of an item list
/// </summary>
public sealed class ClrTypeLineage : TypedItemList<ClrTypeLineage, ClrType>
{

    public static implicit operator ClrTypeLineage(ClrType[] Items)
        => Create(Items);


    public ClrTypeLineage()
        : base(" --> ")
    {

    }

    public ClrType Descendant
        => Items.IsNonEmpty()  
        ? Items[0]  
        : ClrType.Void;

    public IEnumerable<ClrProperty> PublicProperties(ClrTypeLineage lineage)
       => from type in lineage
          from member in type.DeclaredPublicInstanceProperties.Stream()
          select member;
}
