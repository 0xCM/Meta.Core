//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Language;

    
    using Meta.Core;
    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Services;

    using static metacore;    
    using static SignatureTokenizer;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    static partial class SignatureCalculator
    {

        public static SqlSyntaxSignatures CalcSignatures(this ISqlScript source)
        {
            var tokenizer = new SignatureTokenizer();
            var signatures = MutableList.Create<SqlSyntaxSignature>();
            var consumed = setM<TSql.TSqlFragment>();            

            TSqlParser.NativeParser().ParseAny(source.ScriptText).Accept(
                new SignatureVisitor(tSql => {
                    if (consumed.Contains(tSql))
                        return;

                    var sigCalc = tokenizer.CalcSignature(new ParsedSqlFragment(source, tSql));
                    signatures.Add(sigCalc.sig);
                    consumed.AddRange(sigCalc.consumed);
                }));

            return
                SqlSyntaxSignatures.FromSource(signatures, source);
        }

        static IEnumerable<SqlSyntaxSignature> CalcMany(IEnumerable<string> sources)
            => from script in sources.Select(SqlScript.Create)
               from sig in SqlSyntaxSignatures.Create(CalcSignatures(script))
               select sig;
    }

    class SignatureVisitor : TSql.TSqlConcreteFragmentVisitor
    {

        readonly Action<TSql.TSqlFragment> observe;

        public SignatureVisitor(Action<TSql.TSqlFragment> observer)
            => this.observe = observer;

        public override void Visit(TSql.TSqlFragment tSql)
            => observe(tSql);
    }

}