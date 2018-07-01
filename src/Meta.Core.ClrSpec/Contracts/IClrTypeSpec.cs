//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;


using static ClrStructureSpec;

public interface IClrTypeSpec : IClrElementSpec
{
    bool IsStatic { get; }

    bool IsPartial { get; }

    IClrElementName TypeName { get; }

    IReadOnlyList<IClrMemberSpec> Members { get; }

    IReadOnlyList<TypeParameter> TypeParameters { get; }

}

