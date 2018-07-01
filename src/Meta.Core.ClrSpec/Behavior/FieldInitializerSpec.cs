//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public static partial class ClrBehaviorSpec
{

    /// <summary>
    /// Characterizes a field initializer
    /// </summary>
    public sealed class FieldInitializerSpec : ExpressionSpec<FieldInitializerSpec>
    {
        public static implicit operator FieldInitializerSpec(LiteralValueSpec x)
            => new FieldInitializerSpec(x);

        public static implicit operator FieldInitializerSpec(ConstructorInvocationSpec x)
            => new FieldInitializerSpec(x);

        public FieldInitializerSpec(LiteralValueSpec LiteralValue)
            => this.LiteralValue = LiteralValue;
        
        public FieldInitializerSpec(ConstructorInvocationSpec ConstructorInvocation)
            =>  this.ConstructorInvocation = ConstructorInvocation;
        
        public Option<LiteralValueSpec> LiteralValue { get; }

        public Option<ConstructorInvocationSpec> ConstructorInvocation { get; }

        public override string ToString()        
            => LiteralValue.Map(x => x.ToString(), 
                    () => ConstructorInvocation.ToString());
        
    }

}


