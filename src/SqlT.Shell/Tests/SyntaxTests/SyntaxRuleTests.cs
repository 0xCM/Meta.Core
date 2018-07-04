//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using Meta.Core;
    using Meta.Core.Workflow;
    using Meta.Syntax;


    using SqlT.Core;
    using SqlT.Models;
    using SqlT.CSharp;

    using static grammar;
    using static SqlSyntax;

    using CreateTable = SqlGrammar.Statements.Create.Table;

    using G = SqlGrammar;

    [WorkflowNode]
    public class SyntaxRuleTests : WorkflowNode<SyntaxRuleTest>
    {
        protected SyntaxRuleTest Print(SyntaxRuleTest test)
        {
            Notify(test.Passed
                ? inform(test.ToString())
                : error(test.ToString()));

            return test;
        }


        public IEnumerable<SyntaxRule> Flatten(SyntaxRule Source)
        {
            if (Source.Terms.Count == 0)
                yield return Source;
            else
                foreach (var term in Source.Terms)
                    foreach (var t2 in Flatten(term))
                        yield return t2;

        }


        public SyntaxRuleTests(IWorkflowContext C)
            : base(C)
        {
                      
            
        }


        public WorkFlowed<SyntaxRuleTest> CompatibilityLevel()
        {
            var rule = G.Choices.compatibility_level;
            var eval = rule.ToString();
            var expect = "<compatibility_level> ::= { 90 | 100 | 110 | 120 | 130 | 140 }";
            var same = equals(eval, expect);
            return Print(new SyntaxRuleTest(rule, eval, expect, same));

        }

        public WorkFlowed<SyntaxRuleTest> DefineOneOf()
        {
            var rule = oneof(TINYINT, SMALLINT, INT, BIGINT);
            var eval = rule.ToString();
            var expect = " tinyint | smallint | int | bigint ";
            var same = equals(eval, expect);
            return Print( new SyntaxRuleTest(rule, eval, expect, same));            
        }

        public WorkFlowed<SyntaxRuleTest> CombineOneOf()
        {
            var rule1 = oneof(TINYINT, SMALLINT);
            var rule2 = oneof(INT, BIGINT);
            var rule = rule1 + rule2;
            var eval = rule.ToString();
            var expect = " tinyint | smallint | int | bigint ";
            var same = equals(eval, expect);
            return Print( new SyntaxRuleTest(rule, eval, expect, same));
        }

        public WorkFlowed<SyntaxRuleTest> CollateStatement()
        {
            //var lgProfile = C.SqlProxyProfileManager().LoadProfiles(SqlTZ0.Identifier).Single(p => p.Name == "Z0.Lists");
            //var result = C.CSharpProxyGenerator().GenerateFieldLists(lgProfile as SqlFieldListGenerationProfile);

            var types = Microsoft.SqlServer.Dac.Model.ModelSchema.SchemaInstance.AllTypes.ToReadOnlyList();
            
           

            var choices = G.Choices.All().ToReadOnlyList();
            var rule = G.Choices.sql_collation_name;
            var eval = rule.ToString();
            var expect = eval;
            var same = equals(eval, expect);
            return Print(new SyntaxRuleTest(rule, eval, expect, same));

        }

        public WorkFlowed<SyntaxRuleTest> AssignmentRule()
        {
            var rule = group(assign(slot("name"), slot("value")));
            var eval = rule.ToString();
            var expect = "<rule1> ::= {name = value}";
            var same = equals(eval, expect);
            return Print(new SyntaxRuleTest(rule, eval, expect, same));

        }
    }

}