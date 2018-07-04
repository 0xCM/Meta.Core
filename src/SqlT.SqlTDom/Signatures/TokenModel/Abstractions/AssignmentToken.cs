//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    abstract class AssignmentToken<A> : SignatureToken<A> where 
        A : AssignmentToken<A>
    {

        protected AssignmentToken(ClrProperty Property, int TokenLevel)
            : base(TokenLevel)
        {
            this.Property = Property;
        }

        public ClrProperty Property { get; }

    }

}
