//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    partial class BuildSyntax
    {
        public class ProjectDefinition
        {
            IList<ProjectElement> _Elements { get; }
                = new List<ProjectElement>();

            T add<T>(T element)
                where T : ProjectElement
            {
                _Elements.Add(element);
                return element;
            }

            public ProjectDefinition(string ToolsVersion = null, IEnumerable<ProjectElement> Elements = null)
            {
                this.ToolsVersion = ifBlank(ToolsVersion,"15.0");
                this._Elements = new List<ProjectElement>(Elements ?? stream<ProjectElement>());
            }

            public string ToolsVersion { get; set; }
            
            public IEnumerable<ProjectElement> Elements { get; }

            public ProjectImport AddImport(ISymbolicExpression Project, string Label = null, 
                string Condition = null)
                    => add(new ProjectImport(Project, Label, Condition));

            public PropertyGroup AddPropertyGroup(IEnumerable<SymbolicVariable> properties, 
                string Label = null, string Condition = null)
                    => add(new PropertyGroup(map(properties, 
                            p => new PropertyGroupMember(p)), Label, Condition));
        }
    }
}