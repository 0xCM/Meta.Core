//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;


    using static metacore;
    
    public sealed class JobIdentifier : SemanticIdentifier<JobIdentifier, string>
    {

        public static implicit operator JobIdentifier(string x)
            => new JobIdentifier(x);

        protected override JobIdentifier New(string IdentifierText)
            => new JobIdentifier(IdentifierText ?? string.Empty);


        JobIdentifier()
            : base(string.Empty)
        { }

        public JobIdentifier(string text)
            : base(text)
        {

        }

    }

}