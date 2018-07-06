create function [SqlT].[ObjectExists](@ObjectName nvarchar(260)) returns table as return
	select  
		isnull(
			try_convert(bit, 
				case 
					when object_id(@ObjectName) is not null 
						then 1 
					else 0 
				end), 0) as ObjectExists