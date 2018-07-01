//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;



/// <summary>
/// Isolates the weirdness of dealing with the Core Assembly where the Shared Core is referenced    
/// </summary>
class ServiceAgentAdapter : IServiceAgent
{

    object Agent { get; }
    object[] Parameters;

    public ServiceAgentAdapter(object agent)
    {
        this.Agent = agent;
    }

    static object GetPropertyValue(object o, string propertyName)
    {
        var value = default(object);
        var p = o.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (p != null)
        {
            value = p.GetValue(o);
        }

        return value;
    }
    public static T GetPropertyValue<T>(object o, string propertyName) 
        => (T)GetPropertyValue(o, propertyName);


    static MethodInfo GetAgentMethod(Type ImplementationType, string methodName)
    {
        if (String.IsNullOrWhiteSpace(methodName))
            throw new ArgumentException($"The name of the method to invoke on the {ImplementationType.FullName} was not specified");

        var method = ImplementationType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (method == null)
        {

            var ifType = ImplementationType.GetInterface(nameof(IServiceAgent));
            if (ifType == null)
                throw new MissingMemberException($"The agent apparently does not implement the {nameof(IServiceAgent)} interface");

            var ifMethodName = $"{nameof(IServiceAgent)}.{methodName}";
            var map = ImplementationType.GetInterfaceMap(ifType);
            method = map.TargetMethods.FirstOrDefault(m => m.Name == ifMethodName);
            if (method == null)
                throw new MissingMemberException($"The {methodName} operation on the {nameof(IServiceAgent)} could not be found");
        }
        return method;

    }


    public static void InvokeAction(object o, string methodName)
    {
        var method = GetAgentMethod(o.GetType(), methodName);
        method.Invoke(o, new object[] { });
    }

    public static void InvokeAction(object o, string methodName, object arg)
    {
        var method = GetAgentMethod(o.GetType(), methodName);
        method.Invoke(o, new object[] {arg});
    }


    static IEnumerable<Type> DisoverAgents()
    {
        //var appSettings = new ServiceAgentSettings();    
        //var agentBaseDirectory = appSettings.AgentBaseRuntimeFolder;
        var searchDir = Assembly.GetEntryAssembly().Location;
        foreach (var file in Directory.EnumerateFiles(searchDir, "*.Agents.dll"))
        {
            var assembly = Assembly.LoadFrom(file);
            foreach (var type in assembly.GetTypes())
            {
                var attrib = type.GetCustomAttributes().Where(
                    a => a.GetType().FullName == typeof(ServiceAgentAttribute).FullName).FirstOrDefault();
                if (attrib != null)
                    yield return type;
            }

        }

    }

    static string GetAgentIdentifier(Type AgentType)
    {
        var attrib = AgentType.GetCustomAttributes().Where(
            a => a.GetType().FullName == typeof(ServiceAgentAttribute).FullName).FirstOrDefault();
        return (attrib as dynamic)?.AgentIdentifier;
    }

    static Tuple<Exception, IServiceAgent>  TryCreateAgent(Type AgentType)
    {
        try
        {
            return Tuple.Create<Exception, IServiceAgent>(
                null,
                new ServiceAgentAdapter(Activator.CreateInstance(AgentType)));
        }
        catch (Exception e)
        {
            return Tuple.Create<Exception, IServiceAgent>(e, null);
        }
    }


    public static IEnumerable<IServiceAgent> CreateServiceAgents(string[] args, Action<string,Exception> error)
    {
        var types = DisoverAgents().ToList();
        
        foreach(var type in types)
        {
            var identifier = GetAgentIdentifier(type);
            if (args.Length != 0 && !args.Contains(identifier))
                continue;

            var agent = TryCreateAgent(type);
            if (agent.Item2 != null)
                yield return agent.Item2;
            else
                error?.Invoke(identifier, agent.Item1);
        }

    }

    public IApplicationContext Context
        => GetPropertyValue<IApplicationContext>(Agent, nameof(Context));

    public ServiceDescriptor ServiceDescriptor
        => GetPropertyValue<ServiceDescriptor>(Agent, nameof(Context));

    public string AgentName 
        => GetPropertyValue<string>(Agent, nameof(AgentName));

    public string ComponentName
        => AgentName;

    public string AgentStateName 
        => GetPropertyValue<string>(Agent, nameof(AgentStateName));

    public void Dispose() 
        => InvokeAction(Agent, nameof(Dispose));

    public void Start() 
        => InvokeAction(Agent, nameof(Start));

    public void Stop() 
        => InvokeAction(Agent, nameof(Stop));

    public override string ToString() 
        => AgentName;

    public void Initialize(params object[] Parameters)
    {
        this.Parameters = Parameters;
        InvokeAction(Agent, nameof(Initialize));
    }

    public void Pause()
        => InvokeAction(Agent, nameof(Pause));

    public void Resume()
        => InvokeAction(Agent, nameof(Resume));

    public void NoBabble()
        => InvokeAction(Agent, nameof(NoBabble));

    public void UseChannel(AgentNoficationChannel channel)
        => InvokeAction(Agent, nameof(UseChannel), channel);

    public void Babble()
        => InvokeAction(Agent, nameof(Babble));

    public ServiceAgentState AgentState
        => new ServiceAgentState(GetPropertyValue<string>(Agent, nameof(AgentStateName)));

    public IAssemblyDesignator DefiningAssembly
        => Agent.GetType().Assembly.Designator();
}

