//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public abstract class SqlObjectDocumentation<N> : SqlElementDocumetation<N>, ISqlObjectDocumentation<N>
        where N : SqlObjectName<N>, new()
    {
        protected SqlObjectDocumentation()
        {

        }

        protected SqlObjectDocumentation(N Name, string Label, string Description, string Identifier)
            : base(Name, Label, Description, Identifier)
        {
            
        }        

    }
}