//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Provides a convenient way to define a type that precludes the need to
    /// spell-out every bloody detail.
    /// </summary>
    public class TypeTemplateSpec : ValueObject<TypeTemplateSpec>, IClrElementSpec
    {

        public TypeTemplateSpec(IClrElementName TypeName, string TemplateText, params NamedValue[] Parameters)
        {
            this.TypeName = TypeName;
            this.TemplateText = TemplateText;
            this.Parameters = Parameters.ToList();
        }

        /// <summary>
        /// Specifies the name of the type
        /// </summary>
        public IClrElementName TypeName { get; }

        /// <summary>
        /// Specifies the parameterized template that will be expanded
        /// </summary>
        public string TemplateText { get; }

        /// <summary>
        /// Specifies the value of the template parameters to use when expanding
        /// </summary>
        public IReadOnlyList<NamedValue> Parameters { get; }

        public Option<CodeDocumentationSpec> Documentation { get; }

        public ClrAccessKind AccessLevel { get; }

        IReadOnlyList<AttributionSpec> IClrElementSpec.Attributions
            => new AttributionSpec[] { };

        IClrElementName IClrElementSpec.ElementName
            => TypeName;

        public override string FormatValue()
        {
            var result = TemplateText;
            foreach (var param in Parameters)
                result = result.Replace(param.Name, param.Value.ToString());
            return result;
        }
    }



}