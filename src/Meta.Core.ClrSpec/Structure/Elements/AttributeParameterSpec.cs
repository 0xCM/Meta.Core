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
    /// Characterizes an attribute parameter
    /// </summary>
    public sealed class AttributeParameterSpec : ValueObject<AttributeParameterSpec>
    {
        public AttributeParameterSpec(string ParameterName,CoreDataValue ParameterValue, 
            int? ParameterPosition = null)
        {
            this.ParameterName = ParameterName;
            this.ParameterValue = ParameterValue;
            this.ParameterPosition = ParameterPosition;
        }

        /// <summary>
        /// The name of the attribute parameter
        /// </summary>
        public string ParameterName { get; }

        /// <summary>
        /// The value of the paramter
        /// </summary>
        public CoreDataValue ParameterValue { get; }

        /// <summary>
        /// The 0-based position of the parameter, if specified
        /// </summary>
        public int? ParameterPosition { get; }

        public bool IsConstructorParameter 
            => ParameterPosition != null;

        public override string ToString() 
            => $"{ParameterName} = ({ParameterValue})";
    }
}