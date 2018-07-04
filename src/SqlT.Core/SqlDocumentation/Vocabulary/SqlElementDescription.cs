//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public class SqlElementDescription 
    {
        public static readonly SqlElementDescription Empty 
            = new SqlElementDescription(string.Empty);

        public static implicit operator SqlElementDescription(string text) 
            => new SqlElementDescription(text);

        public static implicit operator string(SqlElementDescription doc) 
            => doc?.Text ?? string.Empty;

        public SqlElementDescription(string Text)
        {
            this.Text = Text ?? string.Empty;
        }

        public string Text { get; }

        public override string ToString() 
            => Text;

        public bool IsEmpty
            => this.Text == string.Empty;
    }
}
