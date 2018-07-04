//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;


    public static partial class contracts
    {
        public interface statement : IModel
        {
            IKeyword statement_designator { get; }

        }

        public interface create_statement : statement { }

        public interface alter_statement : statement { }

        public interface statement_list : IModelList<statement> { }

        public interface statement_block : statement_list { }

        public interface clause : IModel
        {
            IKeyphrase designator { get; }
        }


    }
}

