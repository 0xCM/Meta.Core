//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using static metacore;

public static partial class ClrStructureSpec
{

    /// <summary>
    /// Characterizes an argument to a generic type
    /// </summary>
    public sealed class TypeArgument : ValueObject<TypeArgument>
    {

        public TypeArgument(TypeParameter Parameter, IClrTypeName ArgumentValue)
        {
            this.Parameter = Parameter;
            this.ArgumentValue = ArgumentValue;
        }

        /// <summary>
        /// Specifies the parameter for which the argument is supplied
        /// </summary>
        public TypeParameter Parameter { get; }

        /// <summary>
        /// The name of the argument type
        /// </summary>
        public IClrTypeName ArgumentValue { get; }

        public override string ToString()
            => $"{Parameter} : {ArgumentValue}";
    }







}