//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    public class BatchScript : IScript
    {
    
        public BatchScript(Script Content)
        {
            this.Content = Content;
        }

        public Script Content { get; }

        string IScript.Body 
               => Content.Body;

        public override string ToString()
            => Content;
    }
}
