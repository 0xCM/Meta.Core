//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    public interface ISqlElementBuilder : ISqlModelBuilder
    {
        ISqlElementBuilder WithDocumentation(SqlElementDescription documentation);
    }

    public interface ISqlElementBuilder<M> : ISqlElementBuilder, ISqlModelBuilder<M>
        where M : ISqlElement
    {
        new ISqlElementBuilder<M> WithDocumentation(SqlElementDescription documentation);
    }

}