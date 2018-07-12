CREATE PROCEDURE [RF].[BuildTimeOfDayLookup] as
begin
	if not exists (select * from [RF].[TimeOfDayLookup])
	begin
		declare @key int = 0
		declare @h tinyint = 0
		declare @m tinyint = 0
		declare @s tinyint = 0
		while @h <= 23
		begin
			while @m <= 59
			begin
				while @s <= 59
				begin
					insert into [RF].[TimeOfDayLookup](TimeKey, ClockTime, Hour, Minute, Second)
						values(@key, TIMEFROMPARTS(@h, @m, @s, 0, 0), @h, @m, @s)
					set @s = @s + 1 
					set @key = @key + 1
				end
				set @s = 0
				set @m = @m + 1
			end
			set @m = 0
			set @h = @h + 1
		end
	end
end
