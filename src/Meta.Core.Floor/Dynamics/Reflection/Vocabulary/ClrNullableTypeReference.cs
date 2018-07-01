//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static metacore;


/// <summary>
/// Identifies a nullable type
/// </summary>
public sealed class ClrNullableTypeReference : ClrTypeReference
{
    public ClrNullableTypeReference(IClrTypeName TypeName)
        : base(TypeName, true)
    {

    }


}


