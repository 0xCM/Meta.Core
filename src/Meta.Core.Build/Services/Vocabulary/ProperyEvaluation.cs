//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Linq;

    using static metacore;

    public class PropertyEvaluation
    {
        public PropertyEvaluation()
        { }

        public PropertyEvaluation(string PropertyName, string SymbolicValue, string ExpandedValue, bool FromEnvironment)
        {
            this.PropertyName = PropertyName;
            this.SymbolicValue = SymbolicValue;
            this.EpandedValue = ExpandedValue;
            this.FromEnvironment = FromEnvironment;
        }

        public string PropertyName { get; set; }

        public string SymbolicValue { get; set; }

        public string EpandedValue { get; set; }

        public bool FromEnvironment { get; set; }

        public override string ToString()
            => concat("eval(", PropertyName, ",", SymbolicValue, ") = ", 
                    EpandedValue, FromEnvironment ? "(Environment)" : string.Empty);
    }
}
