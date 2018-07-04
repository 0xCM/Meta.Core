//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public abstract class SqlObjectDocumentationBuilder<B,T,D,N> : SqlElementDocumentationBuilder<B,T,D,N>
        where B : SqlObjectDocumentationBuilder<B, T, D, N>
        where T : ISqlObjectProxy
        where D : SqlObjectDocumentation<N>, new()
        where N : SqlObjectName<N>, new()
    {
        protected  SqlObjectDocumentationBuilder(D ElementDocumentation)
            : base(ElementDocumentation)
        {

        }

        protected SqlObjectDocumentationBuilder()
        {

        }

    }
}