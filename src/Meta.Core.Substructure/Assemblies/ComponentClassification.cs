//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public enum ComponentClassification : byte
{
    None = 0,
    Service,
    CommandDefinition,
    CommandExecutor,
    DomainModel,
    DataProxy,
    AgentImplementation,
    AgentManagement,
    AppShell,
    TestShell,
    SystemOperations,
    Workflow,
    MessageDefinition,
    SqlClr,
    TSql,
    Metamodel,
    Library
}


