//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

public abstract class CommandProgression : ICommandProgression
{
    readonly string json;
    readonly CorrelationToken? ct;
    readonly ICommandSpec spec;


    protected CommandProgression(ICommandSpec spec, string json, CorrelationToken? ct = null)
    {
        this.spec = spec;
        this.json = json;
        this.ct = ct;
    }

    protected CommandProgression(ICommandProgression src)
    {
        this.spec = src.Spec;
        this.json = src.CommandJson;
        this.ct = src.CorrelationToken;
             
    }
    protected CommandProgression(CommandProgression src)
    {
        this.spec = src.spec;
        this.json = src.json;
        this.ct = src.ct;
    }

    public ICommandSpec Spec 
        => spec;

    public CommandName CommandName 
        => spec.CommandName;

    public string CommandSpecName 
        => spec.SpecName;

    public string CommandJson 
        => json;

    public CorrelationToken? CorrelationToken 
        => ct;

    public abstract CommandExecutionStatus Status { get; }
}



public abstract class CommandProgression<TSpec> : CommandProgression,  ICommandProgression<TSpec>
    where TSpec : CommandSpec<TSpec>, new()
{
    readonly TSpec spec;


    protected CommandProgression(ICommandProgression src)
        : base(src)
    {
        this.spec = (TSpec)src.Spec;
    }

    protected CommandProgression(TSpec spec, string json, CorrelationToken? ct = null)
        : base(spec, json, ct)
    {
        this.spec = spec;

    }

    protected CommandProgression(CommandProgression<TSpec> src)
        : this(src.spec, src.CommandJson, src.CorrelationToken)
    {

    }

    public new TSpec Spec 
        => spec;


    

    public override string ToString()
        => spec.ToString();

}





