//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


public interface IClrMemberSpec : IClrElementSpec
{
    bool IsStatic { get; }

    bool IsProperty { get; }

    bool IsCustom { get; }

    ClrCustomMemberIdentifier CustomMember { get; }

    IClrElementName DeclaringTypeName { get; }
}



