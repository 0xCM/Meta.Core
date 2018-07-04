//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using SqlT.Models;
    using SqlT.Core;


    using static metacore;

    public class SqlSyntaxSignature
    {

        public SqlSyntaxSignature(ISqlScript SourceScript, string ElementRoot, string Transpilation)
        {
            this.SourceScript = SourceScript;
            this.ElementRoot = ElementRoot;
            this.Transpilation = Transpilation;
        }


        public ISqlScript SourceScript { get; }

        public string ElementRoot { get; }

        public string Transpilation { get; }



        public override string ToString()
            => this.Format();

    }

    public class SqlSyntaxSignatures : TypedItemList<SqlSyntaxSignatures, SqlSyntaxSignature>
    {
        public static SqlSyntaxSignatures FromSource(IEnumerable<SqlSyntaxSignature> sigs, ISqlScript SourceScript)
        {
            var list = Create(sigs);
            list.SourceScript = some(require(SourceScript));
            return list;
        }

        

        
        public SqlSyntaxSignatures() 
            : base("")
        { }


        public Option<ISqlScript> SourceScript { get; private set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            iter(this, sig => sb.AppendLine(sig.ToString()));
            return sb.ToString();
        }


    }

}