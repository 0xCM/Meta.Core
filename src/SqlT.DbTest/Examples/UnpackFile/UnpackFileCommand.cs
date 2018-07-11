//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace DF
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Syntax;
    using sxf = SqlT.Syntax.SqlTypes;
    using static SqlT.Bindings.TypeStructures;
    using static SqlT.Syntax.SqlNativeTypeRefs;

    public sealed class UnpackFileCommand : TableType<UnpackFileCommand>
    {

        public NVARCHAR SourceNodeId { get; }
            = sxf.nvarchar(75, false);

        public NVARCHAR SourceFilePath { get; }
            = sxf.nvarchar(500, false);

        public NVARCHAR TargetNodeId { get; }
            = sxf.nvarchar(75, false);

        public NVARCHAR TargetFilePath { get; }
            = sxf.nvarchar(500, false);

    }



}