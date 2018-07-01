//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;
using static metacore;

public static partial class ClrBehaviorSpec
{

    /// <summary>
    /// Characterizes a variable declaration
    /// </summary>
    public class VariableDeclarationSpec : ExpressionSpec<VariableDeclarationSpec>
    {

        public VariableDeclarationSpec(ClrVariableName name, ClrTypeReference type, IClrExpressionSpec inializer = null)
        {
            this.VariableName = name;
            this.VariableType = type;
            this.Initializer = Initializer;
        }

        public VariableDeclarationSpec(ClrVariableName name, IClrExpressionSpec inializer)
        {
            this.VariableName = name;
            this.Initializer = Initializer;
            
        }

        /// <summary>
        /// The variable's name
        /// </summary>
        public ClrVariableName VariableName { get; }

        /// <summary>
        /// The variable's type, if specified
        /// </summary>
        public Option<ClrTypeReference> VariableType { get; }

        /// <summary>
        /// The variable's initializer, if specified
        /// </summary>
        public Option<IClrExpressionSpec> Initializer { get; }

        public override string ToString()
            => VariableName;

    }

}
