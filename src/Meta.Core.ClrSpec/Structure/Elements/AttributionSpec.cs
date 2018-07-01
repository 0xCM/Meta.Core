//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{

    /// <summary>
    /// Characterizes an attribute application
    /// </summary>
    public sealed class AttributionSpec : ValueObject<AttributionSpec>
    {
        public static AttributionSpec Specify<A>(params AttributeParameterSpec[] parameters)
            where A : Attribute => new AttributionSpec(typeof(A).Name, parameters);

        public static AttributionSpec Specify(Type attribType, params AttributeParameterSpec[] parameters)
            => new AttributionSpec(attribType.Name, parameters);

        public static AttributionSpec Specify(ClrClassName attribName, params AttributeParameterSpec[] parameters)
            => new AttributionSpec(attribName, parameters);


        public AttributionSpec(ClrClassName AttributeName, params AttributeParameterSpec[] parameters)
        {
            this.AttributeName = AttributeName;
            this.Parameters 
                = parameters.Any(p => p.ParameterPosition == null)
                ? parameters.ToReadOnlyList() 
                : parameters.OrderBy(x => x.ParameterPosition.Value).ToReadOnlyList();

        }

        public override string ToString() 
            => AttributeName;

        /// <summary>
        /// The name of the attribute
        /// </summary>
        public ClrClassName AttributeName { get; }

        /// <summary>
        /// The applied parameters
        /// </summary>
        public IReadOnlyList<AttributeParameterSpec> Parameters { get; }

    }


}