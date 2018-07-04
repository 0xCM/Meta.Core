//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Vocabulary
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using SqlT.Core;

    /// <summary>
    /// Characterizes a monadic model builder
    /// </summary>
    public sealed class MonadicModelBuilder
    {
        public MonadicModelBuilder(ClrClass BuilderType, ClrType ModelType)
        {
            this.BuilderType = BuilderType;
            this.ModelType = ModelType;

        }

        /// <summary>
        /// The builder type
        /// </summary>
        public ClrClass BuilderType { get; }

        /// <summary>
        /// The type of model produced by the builder
        /// </summary>
        public ClrType ModelType { get; }

    }
}
