create procedure [SqlDocs].[SyncMarkdownTables]
(
	@Tables [SqlDocs].[MarkdownTableInfo] readonly, 
	@Rows [SqlDocs].[MarkdownTableRow] readonly
) as
	
	declare 
		@LoadTS datetime2(0) = getdate();
	begin transaction

		merge into [SqlDocs].[MarkdownTable] as Dst
			using @Tables as Src on
				Src.SegmentName = Dst.SegmentName
			and	Src.DocumentTitle = Dst.DocumentTitle
			and Src.TablePosition = Dst.TablePosition
		when not matched then insert
		(
			SegmentName,
			DocumentTitle,
			TablePosition,
			[RowCount],
			ColumnCount
		
		)
		values
		(
			Src.SegmentName,
			Src.DocumentTitle,
			Src.TablePosition,
			Src.[RowCount],
			Src.ColumnCount

		)
		when matched and not exists
		(
			select
	
				Src.[RowCount],
				Src.ColumnCount

			intersect

			select

			Dst.[RowCount],
			Dst.ColumnCount

		)
		then update set
			Dst.[RowCount] = Src.[RowCount],
			Dst.ColumnCount = Src.ColumnCount,
			Dst.UpdateTS = getdate()
		when not matched by source then delete;

		
		merge into [SqlDocs].[MarkdownTableRow] as Dst
			using @Rows as Src on
				Src.SegmentName = Dst.SegmentName
			and	Src.DocumentTitle = Dst.DocumentTitle
			and Src.TablePosition = Dst.TablePosition
			and Src.RowNumber = Dst.RowNumber
		when not matched then insert
		(
			SegmentName,
			DocumentTitle,
			TablePosition,
			RowNumber,
			CellValue01,
			CellValue02,
			CellValue03,
			CellValue04,
			CellValue05,
			CellValue06,
			CellValue07,
			CellValue08,
			CellValue09
		)
		values
		(
			Src.SegmentName,
			Src.DocumentTitle,
			Src.TablePosition,
			Src.RowNumber,
			Src.CellValue01,
			Src.CellValue02,
			Src.CellValue03,
			Src.CellValue04,
			Src.CellValue05,
			Src.CellValue06,
			Src.CellValue07,
			Src.CellValue08,
			Src.CellValue09

		)
		when matched and not exists
		(
			select
	
				Src.CellValue01,
				Src.CellValue02,
				Src.CellValue03,
				Src.CellValue04,
				Src.CellValue05,
				Src.CellValue06,
				Src.CellValue07,
				Src.CellValue08,
				Src.CellValue09

			intersect

			select

				Dst.CellValue01,
				Dst.CellValue02,
				Dst.CellValue03,
				Dst.CellValue04,
				Dst.CellValue05,
				Dst.CellValue06,
				Dst.CellValue07,
				Dst.CellValue08,
				Dst.CellValue09

		)
		then update set
			Dst.CellValue01 = Src.CellValue01,
			Dst.CellValue02 =Src.CellValue02,
			Dst.CellValue03 =Src.CellValue03,
			Dst.CellValue04 =Src.CellValue04,
			Dst.CellValue05 =Src.CellValue05,
			Dst.CellValue06 =Src.CellValue06,
			Dst.CellValue07 =Src.CellValue07,
			Dst.CellValue08 =Src.CellValue08,
			Dst.CellValue09 =Src.CellValue09,
			Dst.UpdateTS = getdate()
		when not matched by source then delete;


	commit transaction