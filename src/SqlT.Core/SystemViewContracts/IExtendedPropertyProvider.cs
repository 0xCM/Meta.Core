//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System.Collections.Generic;

    /// <summary>
    /// Realized by elements to which extended to which properties can be applied
    /// </summary>
    public interface IExtendedPropertyProvider 
    {
        IReadOnlyDictionary<string, IExtendedProperty> Properties { get; }
    }

}
