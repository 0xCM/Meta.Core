//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Transforms a <see cref="NewTypeSpec"/> into source code
    /// </summary>
    sealed class NewTypeEmitter : GenEmitter<NewTypeEmitter, NewTypeSpec>
    {

        IEnumerable<TemplateParameter> Parameters(GenContext context, NewTypeSpec spec)
        {
            yield return new TemplateParameter(nameof(spec.WrappedTypeName), spec.WrappedTypeName);
            yield return new TemplateParameter(nameof(spec.DerivedTypeName), spec.DerivedTypeName);
            yield return new TemplateParameter(nameof(context.TargetNamespace), context.TargetNamespace);
        }

        public override IEnumerable<string> Emit(GenContext context, NewTypeSpec spec)
        {
            var template = Templates.Find(TemplateNames.NewType);
            var parameters = Parameters(context, spec).ToArray();
            var expansion = template.Expand(parameters);
            yield return expansion;
        }
    }


}