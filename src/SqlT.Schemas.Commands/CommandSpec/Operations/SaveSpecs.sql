create procedure [CommandSpec].SaveSpecs(@Entries [CommandSpec].CommandLibraryEntry readonly) as
begin
	merge into [CommandSpec].CommandLibrary as Dst using @Entries as Src
		on Dst.CommandSpecName = Src.CommandSpecName
	when not matched then
		insert(CommandSpecName, CommandName, CommandJson)
		values(Src.CommandSpecName, Src.CommandName, Src.CommandJson)
	when matched and not exists
	(
		select
			Src.CommandName,
			Src.CommandJson

		intersect

		select
			Dst.CommandName,
			Dst.CommandJson
	)
	then update set
		Dst.CommandName = Src.CommandName,
		Dst.CommandJson = Src.CommandJson
		;
end
GO
