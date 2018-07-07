//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;



public interface ICoreType : ICoreTypeOps
{
    /// <summary>
    /// The name of the data type
    /// </summary>
    string DataTypeName { get; }

    /// <summary>
    /// The CLR type that represents a value of the core type
    /// </summary>
    Type ClrType { get; }

    /// <summary>
    /// Specifies whether an instance of the type is some sort of integer
    /// </summary>
    bool IsInteger { get; }

    /// <summary>
    /// Specifies whether the type is text-based
    /// </summary>
    bool IsText { get; }

    /// <summary>
    /// Specifies whether an instance of the type is a booean value
    /// </summary>
    bool IsBoolean { get; }

    /// <summary>
    /// Specifies whether an instance of the type is a date/datetime/time value
    /// </summary>
    bool IsTemporal { get; }

    /// <summary>
    /// Specifies whether the data type MAY support the concept of length and whether a reference to the
    /// type MAY specify maximal or absolute length
    /// </summary>
    bool CanSpecifyLength { get; }

    /// <summary>
    /// Specifies whether the data type MAY support the concept of numeric precision and whether a reference to the
    /// type MAY specify maximal or absolute precision
    /// </summary>
    bool CanSpecifyPrecision { get; }

    /// <summary>
    /// Specifies whether the data type MAY support the concept of numeric scale and whether a reference to the
    /// type MAY specify maximal or absolute scale
    /// </summary>
    bool CanSpecifyScale { get; }
}

public interface ICoreType<T> : ICoreType 
    where T : ICoreType
{

    T CoreType { get; }

}



