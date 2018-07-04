//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using static metacore;

    public class TransformationDescription : ValueObject<TransformationDescription>
    {


        public readonly Type BuilderType;
        public readonly string Name;
        public IReadOnlyList<string> Preconditions;

        public TransformationDescription(Type BuilderType, string Name, params string[] Preconditions)
        {
            this.BuilderType = BuilderType;
            this.Name = Name;
            this.Preconditions = rolist(Preconditions);
        }
    }
}
