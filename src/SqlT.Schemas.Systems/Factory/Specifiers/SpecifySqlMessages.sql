create procedure [Factory].[SpecifySqlMessages](@Messages [Factory].[AddSqlMessage] readonly, @DefaultMesageNumbers bit = 1) as
	
	
	if @DefaultMesageNumbers = 1
		merge into [Factory].[AddSqlMessage] as Dst
			using @Messages as Src on
				Src.MessageIdentifier = Dst.MessageIdentifier
			when not matched then insert
			(
				MessageIdentifier,
				Severity,
				MessageText,
				EventLog,
				ReplaceExisting
			)
			values
			(
				Src.MessageIdentifier,
				Src.Severity,
				Src.MessageText,
				Src.EventLog,
				Src.ReplaceExisting
			)
			when matched and not exists
			(
				select				
					Src.Severity,
					Src.MessageText,
					Src.EventLog,
					Src.ReplaceExisting

				intersect

				select

					Dst.Severity,
					Dst.MessageText,
					Dst.EventLog,
					Dst.ReplaceExisting		
			)
			then update set
				Dst.Severity = Src.Severity,
				Dst.MessageText = Src.MessageText,
				Dst.EventLog = Src.EventLog,
				Dst.ReplaceExisting	= Src.ReplaceExisting,
				Dst.UpdateTS = getdate();
	else
		merge into [Factory].[AddSqlMessage] as Dst
			using @Messages as Src on
				Src.MessageIdentifier = Dst.MessageIdentifier
			when not matched then insert
			(
				MessageNumber,
				MessageIdentifier,
				Severity,
				MessageText,
				EventLog,
				ReplaceExisting
			)
			values
			(
				Src.MessageNumber,
				Src.MessageIdentifier,
				Src.Severity,
				Src.MessageText,
				Src.EventLog,
				Src.ReplaceExisting
			)
			when matched and not exists
			(
				select				
					Src.Severity,
					Src.MessageText,
					Src.EventLog,
					Src.ReplaceExisting

				intersect

				select

					Dst.Severity,
					Dst.MessageText,
					Dst.EventLog,
					Dst.ReplaceExisting		
			)
			then update set
				Dst.Severity = Src.Severity,
				Dst.MessageText = Src.MessageText,
				Dst.EventLog = Src.EventLog,
				Dst.ReplaceExisting	= Src.ReplaceExisting,
				Dst.UpdateTS = getdate();
