//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
            
class ServiceAgentConsole : IDisposable
{
    IReadOnlyList<IServiceAgent> agents { get; }

    public ServiceAgentConsole(IEnumerable<IServiceAgent> agents)
    {
        this.agents = agents.ToList();
    }
        
    public void Dispose()
    {
        foreach(var agent in agents)
            agent.Dispose();
         
    }

    public void Run()
    {
        try
        {
            Console.WriteLine("Hit enter to terminate execution");
            foreach (var agent in agents)
            {
                Console.WriteLine($"Initializing {agent} agent");
                agent.Start();                    
            }
            Console.ReadLine();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }

    }


}

                                         