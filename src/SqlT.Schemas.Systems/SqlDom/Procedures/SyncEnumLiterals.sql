create procedure [SqlDom].[SyncEnumLiterals](@Records [SqlDom].[EnumLiteral] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[EnumLiteral] as Dst
		using @Records as Src 
			on Src.EnumName = Dst.EnumName
		   and Src.LiteralValue = Dst.LiteralValue
		when not matched then insert
		(
			EnumName,
			LiteralName,
			LiteralValue
		)
		values
		(
			Src.EnumName,
			Src.LiteralName,
			Src.LiteralValue
		)
		when matched and not exists
		(
			select
				Src.LiteralValue

			intersect

			select
				Dst.LiteralValue


		)
		then update set
			Dst.LiteralValue = Src.LiteralValue,
			Dst.UpdateTS = @LoadTS
		when not matched by source then delete;
	
	
	

GO

