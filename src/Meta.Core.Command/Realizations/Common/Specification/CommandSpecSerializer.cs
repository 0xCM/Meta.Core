//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

/// <summary>
/// Standard serializer for command specifications
/// </summary>
class CommandSpecSerializer : ApplicationService<CommandSpecSerializer, ICommandSpecSerializer>, ICommandSpecSerializer
{
    static IApplicationMessage CommandNameUnspecified(Json j)
        => ApplicationMessage.Error("The command name could not be parsed from the block: @JsonBlock", new
        {
            JsonBlock = j.Text
        });

    static IApplicationMessage CommandSpecNameUnspecified(Json j)
        => ApplicationMessage.Error("The command spec name could not be parsed from the block: @JsonBlock", new
        {
            JsonBlock = j.Text
        });

    static IApplicationMessage CommandTypeNotFound(string CommandName)
        => ApplicationMessage.Error("The command spec for the @CommandName command could not be found", new
        {
            CommandName
        });

    static IApplicationMessage CouldNotMaterialize(string CommandName, Json j)
        => ApplicationMessage.Error("The @CommandName command could not be materialized from the block: @JsonBlock", new
        {
            CommandName,
            JsonBlock = j.Text
        });


    IReadOnlyDictionary<CommandName, CommandSpecDescriptor> SpecDescriptors 
        => Service<ICommandPatternLibrary>().SpecDescriptors();

    IJsonSerializer JsonSerializer 
        => Service<IJsonSerializer>();

    public CommandSpecSerializer(IApplicationContext context)
        : base(context)
    {

    }

    public Option<ICommandSpec> Decode(Json j)
    {
        var args = new CommandArguments(JsonSerializer.DeserializeAttributes(j));

        var cmdName = args.CommandName.ValueOrDefault();
        if (isBlank(cmdName))
            return none<ICommandSpec>(CommandNameUnspecified(j));

        var specName = args.SpecName.ValueOrDefault();
        if (isBlank(specName))
            return none<ICommandSpec>(CommandSpecNameUnspecified(j));

        var type = SpecDescriptors.TryFind(cmdName).Map(d => d.SpecType);
        if (type.IsNone())
            return none<ICommandSpec>(CommandTypeNotFound(cmdName));

        var o = JsonSerializer.ObjectFromJson(type.Require(), j) as ICommandSpec;
        return o != null ? some(o) : none<ICommandSpec>(CouldNotMaterialize(cmdName, j));

    }

    public CommandSpec<T> Decode<T>(Json j) where T : CommandSpec<T>, new()
        => JsonSerializer.ObjectFromJson<T>(j);

    public Json Encode(ICommandSpec spec)
        => JsonSerializer.ObjectToJson(spec);
}
