//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class CommandExecutionContext
{
    public CommandExecutionContext(long? SubmissionId)
    {
        this.SubmissionId = SubmissionId;
    }

    public CommandExecutionContext(CorrelationToken? Correlation)
    {
        this.Correlation = Correlation;
    }

    public CommandExecutionContext(long? SubmissionId, CorrelationToken? Correlation)
    {
        this.SubmissionId = SubmissionId;
        this.Correlation = Correlation;
    }

    public long? SubmissionId { get; }

    public CorrelationToken? Correlation { get; }

}