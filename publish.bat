delete C:\Dev\Tools\SqlT\sqlt.exe
delete C:\Dev\Tools\SqlT\proxygen.exe.config sqlt.exe.config
robocopy bin\lib\net472\ C:\Dev\Tools\SqlT /e
rename C:\Dev\Tools\SqlT\proxygen.exe sqlt.exe
rename C:\Dev\Tools\SqlT\proxygen.exe.config sqlt.exe.config

