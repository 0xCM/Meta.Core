create view [SqlDom].[ElementLineage] as
	with X as
	(
		select 
			ElementName, 
			ParentName, 
			ParentAncestor = cast(null as varchar(250)),
			IsAbstract 
		from 
			[SqlDom].[Element] 
		where 
			ParentName = 'TSqlFragment'

		union all

		select 
			e.ElementName,
			e.ParentName,
			ParentAncestor = X.ParentName,
			e.IsAbstract
		
		from
			[SqlDom].[Element] e 
				inner join X on 
					X.ElementName = e.ParentName
		where
			e.ParentName <> 'TSqlFragment'
	)
	select * from X


	
