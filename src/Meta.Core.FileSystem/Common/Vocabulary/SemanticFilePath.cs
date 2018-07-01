//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

namespace Meta.Core
{

    public abstract class SemanticFilePath<T,N> : FilePath<T>
        where T : SemanticFilePath<T,N>, new()
        where N : FileName<N>, new()
    {

        public SemanticFilePath()
        {

        }

        public SemanticFilePath(string Text)
            : base(Text)
        {

        }


    }

}