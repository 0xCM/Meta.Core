CREATE VIEW [RF].[vCalendarInfo] as
	select
		min(c.CalendarDate) as MinDate,
		max(c.CalendarDate) as MaxDate
	from
		[RF].[Calendar] c
	where
		c.DateKey <> 0