create function [PF].[HostId]() returns nvarchar(75) as
begin
	declare @HostId nvarchar(75) 
		= (select top(1) NodeId from [PF].[ExecutingNode]);
	return @HostId;
end
