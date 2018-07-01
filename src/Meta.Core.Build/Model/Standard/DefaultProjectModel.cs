//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;


    using static BuildSyntax;
    using static symbolics;
    
    

    public static partial class DefaultProjectModel
    {
        public static AreaPropertyGroup AreaProperties()
            => new AreaPropertyGroup();

        public class AreaPropertyGroup : SymbolicPropertyGroup<AreaPropertyGroup>
        {

            public AreaPropertyGroup()
                : base("common/area")
            {
                area_distid = DevArea.CreateReference();
                TopDir = symbolic(symbolic("DevAreaRoot"), symbolic(nameof(DevArea)));
            }

            public SymbolicVariable DevArea
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable area_distid
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable TopDir
            {
                get { return read(); }
                set { write(value); }
            }

            public SymbolicVariable TopConfigDir
            {
                get { return read(); }
                set { write(value); }
            }
        }
    }
}