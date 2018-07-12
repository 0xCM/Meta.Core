create view [PF].[ExecutingNode] as
	select 
		n.NodeId, 
		n.NodeName, 
		n.HostName, 
		n.HostIP
	from 
		[PF].[PlatformServerRegistry] n 
			where n.NodeName in (select VariableValue from [PF].[PlatformVariableStore] where VariableName = 'SystemNode')
		

GO

