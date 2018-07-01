//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public sealed class TargetDesignator : SemanticIdentifier<TargetDesignator, ClrItemIdentifier>
    {
        public static implicit operator TargetDesignator(ClrItemIdentifier Identifier)
            => new TargetDesignator(Identifier);

        protected override TargetDesignator New(string IdentifierText)
            => new TargetDesignator(new ClrItemIdentifier(IdentifierText));

        TargetDesignator(ClrItemIdentifier Identifier)
            : base(Identifier)
        { }

    }
}
