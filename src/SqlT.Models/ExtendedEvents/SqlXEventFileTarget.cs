//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;


    public sealed class SqlXEventFileTarget : SqlXEventTarget<SqlXEventFileTarget>
    {
        public SqlXEventFileTarget(FilePath Path)
        {
            this.Path = Path;
        }

        public FilePath Path { get; }

        public override string ToString()
            => Path.ToString();


    }


}