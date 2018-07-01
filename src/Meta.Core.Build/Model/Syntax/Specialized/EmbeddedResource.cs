//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System.Collections.Generic;

    partial class BuildSyntax
    {
        /*
         <EmbeddedResource Include="Scenarios\SelectConvert.sql">
            <LogicalName>SqlScript04.sql</LogicalName>
         </EmbeddedResource>
        */
        public class EmbeddedResource : ItemGroupMember<EmbeddedResource>
        {
            public EmbeddedResource(ISymbolicExpression Include, SymbolicVariable LogicalName, string Label, string Condition = null)
                : base(nameof(EmbeddedResource),Include, Label, Condition)
            {
                this.LogicalName = LogicalName;
            }

            public SymbolicVariable LogicalName { get; set; }


        }
    }
}
