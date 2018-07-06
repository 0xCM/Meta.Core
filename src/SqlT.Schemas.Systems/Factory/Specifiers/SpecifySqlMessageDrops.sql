create procedure [Factory].[SpecifySqlMessageDrops](@Specs [Factory].[DropSqlMessage] readonly) as
	merge into [Factory].[DropSqlMessage] as Dst
	using @Specs as Src on
		Src.MessageNumber = Dst.MessageNumber
	when not matched then insert
	(
		MessageNumber,
		MessageLanguage
	)
	values
	(
		Src.MessageNumber,
		Src.MessageLanguage
	)
	when matched and not exists
	(
		select Src.MessageLanguage intersect select Dst.MessageLanguage
	)
	then update set
		Dst.MessageLanguage = Src.MessageLanguage,
		Dst.UpdateTS = getdate();



	