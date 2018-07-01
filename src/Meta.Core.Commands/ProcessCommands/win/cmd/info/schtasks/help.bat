echo off

set helpfile=help.info
set sep=---------------------------------------------------------------------
set command=schtasks

echo %sep% > %helpfile%
echo docs:    https://goo.gl/gku8UD >> %helpfile%
echo command: %command% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /? >> %helpfile%

set action=Run
echo %sep% >> %helpfile%
echo %command% /%action% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /%action% /? >> %helpfile%

set action=Create
echo %sep% >> %helpfile%
echo %command% /%action% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /%action% /? >> %helpfile%

set action=Query
echo %sep% >> %helpfile%
echo %command% /%action% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /%action% /? >> %helpfile%

set action=Change
echo %sep% >> %helpfile%
echo %command% /%action% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /%action% /? >> %helpfile%

set action=End
echo %sep% >> %helpfile%
echo %command% /%action% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /%action% /? >> %helpfile%

set action=ShowSid
echo %sep% >> %helpfile%
echo %command% /%action% /? >> %helpfile%
echo %sep% >> %helpfile%
%command% /%action% /? >> %helpfile%

exit