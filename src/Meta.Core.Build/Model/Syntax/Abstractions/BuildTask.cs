//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    partial class BuildSyntax
    {

        public abstract class BuildTask<T> : SyntaxElement<T>
            where T : BuildTask<T>
        {

            public BuildTask(ElementDescriptor Descriptor)
                : base(Descriptor)
            {

            }




        }
    }

}