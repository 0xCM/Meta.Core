create procedure SqlTest.pTable04Insert(@Code nvarchar(10), @startDate date, @endDate date) as
	set nocount on
	declare @Id int = next value for SqlTest.Seq03
	insert SqlTest.Table04(Id, Code, StartDate, EndDate) values (@Id, @Code, @startDate, @endDate)
	set nocount off
	return @Id
	