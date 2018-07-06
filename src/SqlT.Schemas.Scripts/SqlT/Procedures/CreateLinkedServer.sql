CREATE PROCEDURE [SqlT].[CreateLinkedServer](@Alias nvarchar(128), @HostName nvarchar(128), @User nvarchar(128), @Password nvarchar(128)) as
begin


exec master.dbo.sp_addlinkedserver 
	@server = @Alias, 
	@srvproduct=@HostName, 
	@provider=N'SQLOLEDB', 
	@datasrc=@HostName

 
exec master.dbo.sp_addlinkedsrvlogin 
	@rmtsrvname=@Alias,
	@useself=N'False',
	@locallogin=NULL,
	@rmtuser=@User,
	@rmtpassword=@Password


exec master.dbo.sp_serveroption @server=@Alias, @optname=N'collation compatible', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'data access', @optvalue=N'true'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'dist', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'pub', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'rpc', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'rpc out', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'sub', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'connect timeout', @optvalue=N'0'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'collation name', @optvalue=null

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'lazy schema validation', @optvalue=N'false'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'query timeout', @optvalue=N'0'

exec master.dbo.sp_serveroption @server=@Alias, @optname=N'use remote collation', @optvalue=N'true'



end
