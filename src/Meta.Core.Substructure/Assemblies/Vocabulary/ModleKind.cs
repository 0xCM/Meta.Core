//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

/// <summary>
/// Classifies a module
/// </summary>
public enum ModuleKind
{
    None = 0,
    AppService,
    CommandSpec,
    CommandExec,
    Domain,
    DataProxy,
    AgentService,
    AgentController,
    SystemShell,
    TestShell,
    Operations,
    Workflow
}


