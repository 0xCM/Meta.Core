create procedure [CommandSpec].SaveDefinitions(@Records [CommandSpec].CommandDefinitionRecord readonly) as
begin
	merge into [CommandSpec].CommandDefinition as Dst using @Records as Src
		on Dst.CommandName = Src.CommandName
	when not matched then
		insert(CommandName, CommandDescription)
		values(Src.CommandName, Src.CommandDescription)
	when matched and not exists
	(
		select
			Src.CommandDescription

		intersect

		select
			Dst.CommandDescription
	)
	then update set
		Dst.CommandDescription = Src.CommandDescription;
end
GO
