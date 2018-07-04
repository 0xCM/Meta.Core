//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Syntax;


    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Cotract for scripts that specify elements
    /// </summary>
    public interface ISqlElementSpecScript : ISqlModelScript
    {
        string ModelTypeIdentifer { get; }

        IName ElementName { get; }
    }
}
