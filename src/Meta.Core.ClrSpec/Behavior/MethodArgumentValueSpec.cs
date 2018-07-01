//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static ClrStructureSpec;
using static metacore;

public static partial class ClrBehaviorSpec
{

    /// <summary>
    /// Characterizes a method argument value
    /// </summary>
    public class MethodArgumentValueSpec : ValueObject<MethodArgumentValueSpec>
    {

        public MethodArgumentValueSpec(string ArgumentName, IClrExpressionSpec ValueExpression, int? ArgumentPosition = null)
        {
            this.ArgumentName = ArgumentName;
            this.ValueExpression 
                =   ValueExpression == null 
                ? none<IClrExpressionSpec>() 
                : some(ValueExpression);
            this.ArgumentPosition = ArgumentPosition;
        }

        public MethodArgumentValueSpec(int ArgumentPosition, IClrExpressionSpec ValueExpression)
        {
            this.ArgumentPosition = ArgumentPosition;
            this.ValueExpression = 
                ValueExpression == null
                ? none<IClrExpressionSpec>()
                : some(ValueExpression);
            this.ArgumentName = string.Empty;
        }

        public MethodArgumentValueSpec(int ArgumentPosition, string ArgumentName, IClrExpressionSpec ValueExpression)
        {
            this.ArgumentName = ArgumentName;
            this.ValueExpression =
                ValueExpression == null
                ? none<IClrExpressionSpec>()
                : some(ValueExpression);
            this.ArgumentPosition = ArgumentPosition;
        }

        public MethodArgumentValueSpec(int ArgumentPosition, IClrElementName ArgumentName, IClrExpressionSpec ValueExpression)
        {
            this.ArgumentName = ArgumentName.SimpleName.Value;
            this.ValueExpression =
                ValueExpression == null
                ? none<IClrExpressionSpec>()
                : some(ValueExpression);
            this.ArgumentPosition = ArgumentPosition;
        }

        public MethodArgumentValueSpec(int ArgumentPosition, ClrMethodParameterName ArgumentName, IClrExpressionSpec ValueExpression)
        {
            this.ArgumentName = ArgumentName;
            this.ValueExpression =
                ValueExpression == null
                ? none<IClrExpressionSpec>()
                : some(ValueExpression);
            this.ArgumentPosition = ArgumentPosition;
        }

        /// <summary>
        /// The argument name
        /// </summary>
        public string ArgumentName { get; }

        /// <summary>
        /// The argument's relative position
        /// </summary>
        public int? ArgumentPosition { get; }

        /// <summary>
        /// The argument's value
        /// </summary>
        public Option<IClrExpressionSpec> ValueExpression { get; }

        public override string ToString()
            => ArgumentPosition != null
            ? $"{ArgumentPosition} : {ValueExpression}"
            : $"{ArgumentName} : {ValueExpression}";
    }

    public static MethodArgumentValueSpec SpecifyArgumentValue(this ClrMethodParameterName ParameterName, 
        IClrExpressionSpec ValueExpression) 
            => new MethodArgumentValueSpec(ParameterName, ValueExpression);

    public static MethodArgumentValueSpec SpecifyArgumentValue(this ClrMethodParameterName ParameterName, 
        int Position, IClrExpressionSpec ValueExpression)
            => new MethodArgumentValueSpec(Position, ParameterName, ValueExpression);

    public static MethodArgumentValueSpec SpecifyArgumentValue(this ClrMethodParameter Parameter, 
        IClrExpressionSpec ValueExpression)
            => new MethodArgumentValueSpec(Parameter.Position, Parameter.Name, ValueExpression);

    public static MethodArgumentValueSpec SpecifyArgumentValue(this MethodParameterSpec Parameter, 
        IClrExpressionSpec ValueExpression)
            => Parameter.Position.MapValueOrElse(
                pos => new MethodArgumentValueSpec(pos, Parameter.Name, ValueExpression), 
                () => new MethodArgumentValueSpec(Parameter.Name.SimpleName, ValueExpression));
        

}

