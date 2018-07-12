create procedure [RF].[RebuildCalendar](@MinDate date = '1995-01-01', @MaxDate date = '2025-12-31') as
	set nocount on
 
	truncate table [RF].[Calendar]
	
	declare @CurrentDate date = @MinDate
	while (@CurrentDate <= @MaxDate)
	begin
	 
		insert [RF].[Calendar]
		(
			[DateKey],
			[DateName],
			[CalendarDate],
			[DayOfWeek],
			[DayOfMonth],
			[DayOfYear],
			[DayName],
			[Week],
			[Month],
			[MonthName],
			[Year],
			IsWeekday,
			IsFedHoliday,
			IsFirstDayOfMonth,
			FirstDateOfMonth,
			IsLastDayOfMonth,
			LastDateOfMonth,
			IsFirstDayOfYear,
			IsLastDayOfYear
		)
		select
			[DateKey] = convert(int, convert(varchar(20), @CurrentDate, 112)),
			[DateName] = format(@CurrentDate, 'yyyy-MM-dd'),
			[CalendarDate]= @CurrentDate,
			[DayOfWeek]= datepart(WEEKDAY, @CurrentDate),
			[DayOfMonth]= datepart(day, @CurrentDate),
			[DayOfYear] = datepart(dayofyear,@CurrentDate),
			[DayName]= datename(WEEKDAY, @CurrentDate),
			[Week] = datepart(week, @CurrentDate),
			[Month] = datepart(MONTH, @CurrentDate),
			[MonthName] = datename(month, @CurrentDate), 
			[Year] = datepart(YEAR,@CurrentDate),
			IsWeekday = case when 
				datepart(weekday, @CurrentDate) = 1 or 
				datepart(weekday, @CurrentDate) = 7  then 0 else 1 end,
			IsFedHoliday = 0,
			IsFirstDayOfMonth = case datepart(day, @CurrentDate) when 1 then 1 else 0 end,
			FirstDateOfMonth = datefromparts(datepart(year, @CurrentDate), datepart(month, @CurrentDate), 1),
			IsLastDayOfMonth = case eomonth(@CurrentDate) when @CurrentDate then 1 else 0 end,
			LastDateOfMonth = datefromparts(datepart(year, @CurrentDate), datepart(month, @CurrentDate), datepart(day,eomonth(@CurrentDate))),
			IsFirstDayOfYear = case dateadd(year, datediff(year,0,@CurrentDate), 0) when @CurrentDate then 1 else 0 end,
			IsLastDayOfYear = case dateadd(year, datediff(year,0,@CurrentDate) + 1, -1) when @CurrentDate then 1 else 0 end		
				;
			
			set @CurrentDate = dateadd(day, 1, @CurrentDate)
		end
