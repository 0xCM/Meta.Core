//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlTypeTableEntry
    {
        public SqlTypeTableEntry(long TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public long TypeCode { get; }

        public string Identifier { get; }

        public string Label { get; }

        public string Description { get; }

        public override string ToString()
            => $"{Identifier} = {TypeCode}";
    }
}
