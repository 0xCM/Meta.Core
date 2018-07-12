create function [PF].[SqlNodeId]() returns nvarchar(75) as
begin
	declare @Id nvarchar(75) = (select SqlNodeId from [PF].[ExecutingServer]);

	return @Id
end
