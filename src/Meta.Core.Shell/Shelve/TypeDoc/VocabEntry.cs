//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class VocabEntry
    {
        public VocabEntry(Type TypeUri, Type TargetType)
        {
            this.TypeUri = TypeUri;
            this.TargetType = TargetType;
        }

        public Type TypeUri { get; }
        public Type TargetType { get; }

        public override string ToString()
            => $"{TypeUri.FullName.Replace('.', '/')}/{TargetType.Name}";


    }



}