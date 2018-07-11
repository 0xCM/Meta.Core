//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;    

    using static metacore;
    using SqlT.Core;
    using SqlT.Models;

    public interface ISqlMetadataCapture
    {
        Option<MetadataCaptureSummary> CaptureMetadata(SqlConnectorLink<SqlMetadataSelectionOptions> Specification);        
    }

}