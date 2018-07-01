//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{

    /// <summary>
    /// Represents a keyword that identifies an intrinic type
    /// </summary>
    /// <typeparam name="k">The keyword type</typeparam>
    public abstract class TypeKeyword<k> : Keyword<k>, ITypeKeyword
        where k : TypeKeyword<k>
    {
        protected TypeKeyword(string name)
            : base(name)
        {

        }
    }
}