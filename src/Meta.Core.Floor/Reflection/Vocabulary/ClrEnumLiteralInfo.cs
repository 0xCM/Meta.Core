//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    /// <summary>
    /// Describes an enumeration literal
    /// </summary>
    public class ClrEnumLiteralInfo
    {
        public ClrEnumLiteralInfo()
        {
            
        }

        public ClrEnumLiteralInfo(ClrEnumLiteralName LiteralName, CoreDataValue LiteralValue)
        {
            this.Name = LiteralName;
            this.Value = LiteralValue;
        }

        /// <summary>
        /// The name of the literal
        /// </summary>
        public ClrEnumLiteralName  Name { get; set; }            

        /// <summary>
        /// The literal value
        /// </summary>
        public CoreDataValue Value { get; set; }

        public override string ToString()
            => $"{Name} = {Value}";

    }

}