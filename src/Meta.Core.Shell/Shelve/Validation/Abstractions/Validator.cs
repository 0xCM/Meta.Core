//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Supertype for types that produce <see cref="ValidationResult"/> values during
    /// the course of verifying whether a given element adheres to the rules of the problem domain
    /// </summary>
    /// <typeparam name="S">The type of the element being validated</typeparam>
    public abstract class Validator<S>
    {
        public static implicit operator ValidationResult(Validator<S> x) 
            => x.Validate();

        protected readonly S Subject;

        protected Validator(S Subject)
        {
            this.Subject = Subject;
        }

        protected abstract ValidationResult Validate();
    }
}
