//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static metacore;

using static CommandStatusMessages;

public class CommandPatternLibrary : ApplicationService<CommandPatternLibrary, ICommandPatternLibrary>, ICommandPatternLibrary
{
    Dictionary<Type, CommandExecDescriptor> DescribedPatterns { get; } 
        = new Dictionary<Type, CommandExecDescriptor>();

    Dictionary<CommandName, CommandSpecDescriptor> DescribedSpecs { get; } 
        = new Dictionary<CommandName, CommandSpecDescriptor>();

    Dictionary<Type, ICommandExecutionService> PatternCache { get; }
        = new Dictionary<Type, ICommandExecutionService>();

    IEnumerable<CommandExecDescriptor> Patterns(IEnumerable<Type> types)
        => from t in types
           where Attribute.IsDefined(t, typeof(CommandPatternAttribute))
           && t.BaseType.IsGenericType && !t.IsAbstract
           let typeArgs = t.BaseType.GetGenericArguments()
           where typeArgs.Length >= 2
           let specType = typeArgs[1]
           select new CommandExecDescriptor
           {
               PatternType = t,
               SpecType = specType,
               CommandName = CommandSpecDescriptor.FromSpecType(specType).CommandName
           };

    public CommandPatternLibrary(IApplicationContext Context)
        : base(Context)
    {
        var types = Context.Service<IAssemblyRegistrar>().GetAssemblyTypes();
        Absorb(types);
    }

    public void Absorb(IEnumerable<Type> types)
    {
        var specDescriptors = 
            (from t in types
                let descriptor = CommandSpecDescriptor.TryGetFromType(t)
                where descriptor.Exists
                select descriptor.Require()
                );

        var descriptorDupes = from d in specDescriptors
                           group d by d.CommandName into nameGroup
                           where nameGroup.Count() > 1
                           select nameGroup.Key;
        var descriptorDupeList = rolist(descriptorDupes);
        if (descriptorDupeList.Count != 0)
            throw new Exception($"Command names are required to be unique and {descriptorDupeList.Count} duplicates were found: " + string.Join("; ", descriptorDupeList));

        var specDescriptorIndex = specDescriptors.ToDictionary(x => x.CommandName);

        var executors = Patterns(types).ToList();
        var execDupes = from x in executors
                        group x by x.SpecType into g
                        where g.Count() > 1
                        select g.Key;
        var execDupeList = rolist(execDupes);
        if (execDupeList.Count != 0)
            throw new Exception($"Command names are required to be unique and {execDupeList.Count} duplicates were found: " + string.Join("; ", execDupeList));

        var execDescriptorIndex = executors.ToDictionary(x => x.SpecType);

        foreach (var spec in specDescriptorIndex)
        {
            var specType = spec.Value.SpecType;
            DescribedSpecs[spec.Key] = spec.Value;
            if (execDescriptorIndex.ContainsKey(specType))
            {
                var execDescriptor = execDescriptorIndex[specType];
                DescribedPatterns[specType] = execDescriptor;
                PatternCache[specType] = (ICommandExecutionService)Activator.CreateInstance(execDescriptor.PatternType, Context);
            }
        }
        
    }

    public void Absorb(IEnumerable<Assembly> assemblies)
        => Absorb(assemblies.SelectMany(x => x.GetTypes()));
    
    public Option<CommandExecDescriptor> PatternDescriptor(CommandName CommandName)
    {
        var spec = DescribedSpecs.TryFind(CommandName);
        if (spec)
        {
            var specType = spec.Require().SpecType;
            foreach (var t in DescribedPatterns.Keys)
            {
                if (specType == t || specType.IsSubclassOf(t))
                    return DescribedPatterns[t];
            }
        }
        return none<CommandExecDescriptor>();
    }

    public Option<CommandExecDescriptor> PatternDescriptor(Type SpecType)
        => (from t in DescribedPatterns.Keys
            where t == SpecType || t.IsSubclassOf(SpecType)
            select DescribedPatterns[t]).FirstOrDefault();

    public IReadOnlyList<CommandExecDescriptor> PatternDescriptors()
       => DescribedPatterns.Values.ToList();

    public IReadOnlyDictionary<CommandName, CommandSpecDescriptor> SpecDescriptors()
        => DescribedSpecs;

    public Option<CommandSpecDescriptor> SpecDescriptor(CommandName CommandName)
        => DescribedSpecs.TryFind(CommandName);

    Option<CommandSpecDescriptor> ICommandPatternLibrary.SpecDescriptor<TSpec>()
        => DescribedSpecs.Values.Where(x => x.SpecType == typeof(TSpec)).FirstOrDefault();

    Option<CommandSpecDescriptor> ICommandPatternLibrary.SpecDescriptor(Type SpecType)
        => DescribedSpecs.Values.Where(x => x.SpecType == SpecType).FirstOrDefault();

    public IEnumerable<ICommandExecutionService> Patterns()
        => PatternCache.Values;

    public Option<ICommandExecutionService> Pattern(Type SpecType)
    {
        var pattern = PatternCache.Values.FirstOrDefault(p => p.SpecType == SpecType);
        return
            pattern == null
            ? none<ICommandExecutionService>(PatternNotFound(SpecType))
            : some(pattern);
    }
        
    public Option<ICommandExecutionService> Pattern(CommandName Name)
    {
        var pattern = PatternCache.Values.FirstOrDefault(p => p.CommandName == Name);
        return
              pattern == null
            ? none<ICommandExecutionService>(PatternNotFound(Name))
            : some(pattern);
    }

    public Option<ICommandExecutionService<TSpec>> Pattern<TSpec>()
        where TSpec : CommandSpec<TSpec>, new()
        => from p in PatternDescriptor(typeof(TSpec))
                from sp in PatternCache.TryFind(p.SpecType)
                let csp = cast<ICommandExecutionService<TSpec>>(sp)
                select csp;

    public Option<ICommandExecutionService<TSpec, TPayload>> Pattern<TSpec, TPayload>()
        where TSpec : CommandSpec<TSpec,TPayload>, new()
        =>
        from p in PatternDescriptor(typeof(TSpec))
                from sp in PatternCache.TryFind(p.SpecType)
                let csp = cast<ICommandExecutionService<TSpec, TPayload>>(sp)
                select csp;        
}
