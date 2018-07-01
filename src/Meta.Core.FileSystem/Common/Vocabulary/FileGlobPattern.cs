//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Linq;


    /// <summary>
    /// Defines a pattern-based file selection operation
    /// </summary>
    public sealed class FileGlobPattern 
    {
        public static implicit operator FileGlobPattern(string Expression)
            => new FileGlobPattern(Expression);

        public static implicit operator string(FileGlobPattern Pattern)
            => Pattern.Expression;

        public FileGlobPattern(string Expression)
        {
            this.Expression = Expression;
        }

        public string Expression { get; }

        public override string ToString()
            => Expression;

    }
 


}