//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

using static metacore;

/// <summary>
/// Standard serializer for command specifications
/// </summary>
class CommandSpecSerializer : ApplicationService<CommandSpecSerializer, ICommandSpecSerializer>, ICommandSpecSerializer
{
    static IAppMessage CommandNameUnspecified(Json j)
        => AppMessage.Error("The command name could not be parsed from the block: @JsonBlock", new
        {
            JsonBlock = j.Text
        });

    static IAppMessage CommandSpecNameUnspecified(Json j)
        => AppMessage.Error("The command spec name could not be parsed from the block: @JsonBlock", new
        {
            JsonBlock = j.Text
        });

    static IAppMessage CommandTypeNotFound(string CommandName)
        => AppMessage.Error("The command spec for the @CommandName command could not be found", new
        {
            CommandName
        });

    static IAppMessage CouldNotMaterialize(string CommandName, Json j)
        => AppMessage.Error("The @CommandName command could not be materialized from the block: @JsonBlock", new
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
