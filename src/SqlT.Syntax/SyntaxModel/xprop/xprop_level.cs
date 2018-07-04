//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using sxc = contracts;

    /// <summary>
    /// Represents an extended property level
    /// </summary>
    /// <remarks>
    /// SQL Server defines only three: Level 0, Level 1 and Level 2
    /// </remarks>
    public sealed class xprop_level : Model<xprop_level>  
    {

        public static readonly xprop_level Undefined = new xprop_level(255);
        public static readonly xprop_level Level0 = new xprop_level(0);
        public static readonly xprop_level Level1 = new xprop_level(1);
        public static readonly xprop_level Level2 = new xprop_level(2);

        public static implicit operator xprop_level(byte LevelNumber)
        {
            switch(LevelNumber)
            {
                case 0: return Level0;
                case 1: return Level1;
                case 2: return Level2;
            }
            return Undefined;
        }

        internal xprop_level(byte Value)
        {
            this.Value = Value;
        }

        public byte Value { get; }

        public string LevelName
            => $"@level{Value}type";
    }
}
