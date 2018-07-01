@ECHO OFF
REM.-- Prepare the Command Processor
SETLOCAL ENABLEEXTENSIONS

REM --
REM -- Copyright note
REM -- This script is provided as is.  No waranty is made, whatso ever.
REM -- You may use and modify the script as you like, but keep the version history with
REM -- recognition to http://www.dostips.com in it.
REM --

REM Version History:
REM         XX.XXX      YYYYMMDD Author Description
SET "version=01.000"  &:20051201 p.h.   initial version, origin http://www.dostips.com
SET "version=01.001"  &:20060122 p.h.   Fix missing exclamation marks in documentation (http://www.dostips.com)
SET "version=01.002"  &:20060218 p.h.   replaced TEXTAREA with PRE XMP (http://www.dostips.com)
SET "version=01.003"  &:20060218 p.h.   php embedding (http://www.dostips.com)
SET "version=01.004"  &:20060723 p.h.   fix page links for FireFox (http://www.dostips.com)
SET "version=01.005"  &:20061015 p.h.   invoke HELP via '"call" help', allows overriding help command with a help.bat file (http://www.dostips.com)
SET "version=01.006"  &:20061015 p.h.   cleanup progress indicator (http://www.dostips.com)
SET "version=01.007"  &:20080316 p.h.   use codepage 1252 to support european users (http://www.dostips.com)
SET "version=02.000"  &:20080316 p.h.   use FOR command to generate HTML, avoids most escape characters (http://www.dostips.com)
SET "version=02.000"  &:20100201 p.h.   now using css and xhtml
REM !! For a new version entry, copy the last entry down and modify Date, Author and Description
SET "version=%version: =%"

for /f "delims=: tokens=2" %%a in ('chcp') do set "restore_codepage=%%a"
chcp 1252>NUL

set "z=%~dpn0.txt"

del "%~dpn0.txt"

set "title=DOS Command Index"
for /f "tokens=*" %%a in ('ver') do set "winver=%%a"

echo.Creating the header ...
for %%A in (
            "%title% (%winver%)"
			"%~nx0"
            ) do echo.%%~A"%z%"
        
echo.Creating the index ...
set /a cnt=0
for /f "tokens=1,*" %%a in ('"help|findstr /v /b /c:" " /c:"For more" /c:"SC""') do (
	if "%%b" NEQ "" (
		for %%A in (
				"<entry>%%a - %%b</entry>"
				) do echo.%%~A>>"%z%"
		set /a cnt+=1
	)
)
for %%A in (
            "___________________________________________________________________________"
            ) do echo.%%~A>>"%z%"

echo.Extracting HELP text ...
call:initProgress cnt
for /f "tokens=1,*" %%a in ('"help|findstr /v /b /c:" " /c:"For more" /c:"SC""') do (
	if "%%b" NEQ "" (
		echo.Processing %%a
		for %%A in (
				"%%a%%a"				
				) do echo.%%~A"%z%"
		call help %%a >>"%z%" 2>&1
		echo "%z%"
		for %%A in (
				"---------------------------------------------------------------------------"
				) do echo.%%~A>>"%z%"
		call:tickProgress
	)
)

echo.Injecting source script ...
for %%A in (
            "This %title% has been created automatically by the following DOS batch script:"
            ) do echo.%%~A>>"%z%"
type "%~f0" >>"%z%"



chcp %restore_codepage%>NUL
explorer "%z%"

:SKIP
REM.-- End of application
FOR /l %%a in (5,-1,1) do (TITLE %title% -- closing in %%as&ping -n 2 -w 1 127.0.0.1>NUL)
TITLE Press any key to close the application&ECHO.&GOTO:EOF


::-----------------------------------------------------------
::helper functions follow below here
::-----------------------------------------------------------


:initProgress -- initialize an internal progress counter and display the progress in percent
::            -- %~1: in  - progress counter maximum, equal to 100 percent
::            -- %~2: in  - title string formatter, default is '[P] completed.'
set /a "ProgressCnt=-1"
set /a "ProgressMax=%~1"
set "ProgressFormat=%~2"
if "%ProgressFormat%"=="" set "ProgressFormat=[PPPP]"
set "ProgressFormat=%ProgressFormat:[PPPP]=[P] completed.%"
call :tickProgress
GOTO:EOF


:tickProgress -- display the next progress tick
set /a "ProgressCnt+=1"
SETLOCAL
set /a "per=100*ProgressCnt/ProgressMax"
set "per=%per%%%"
call title %%ProgressFormat:[P]=%per%%%
GOTO:EOF
 