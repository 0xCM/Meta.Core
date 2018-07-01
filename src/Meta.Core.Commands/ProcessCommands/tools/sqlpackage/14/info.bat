echo off

set tool=sqlpackage.14
set sep=--------------------------------------------------------------------------------

set helpfile=info.txt
set args=/?
set command=%tool% %args% > %helpfile%
%command% >> %helpfile%

set action=Publish
set helpfile=info.%action%.txt
set args=/? /Action:%action%
set command=%tool% %args%
echo %command% > %helpfile%
echo %sep% >> %helpfile%
%command% >> %helpfile%

set action=Script
set helpfile=info.%action%.txt
set args=/? /Action:%action%
set command=%tool% %args%
echo %command% > %helpfile%
echo %sep% >> %helpfile%
%command% >> %helpfile%

set action=Export
set helpfile=info.%action%.txt
set args=/? /Action:%action%
set command=%tool% %args%
echo %command% > %helpfile%
echo %sep% >> %helpfile%
%command% >> %helpfile%

set action=Import
set helpfile=info.%action%.txt
set args=/? /Action:%action%
set command=%tool% %args%
echo %command% > %helpfile%
echo %sep% >> %helpfile%
%command% >> %helpfile%

set action=DeployReport
set helpfile=info.%action%.txt
set args=/? /Action:%action%
set command=%tool% %args%
echo %command% > %helpfile%
echo %sep% >> %helpfile%
%command% >> %helpfile%

set action=DriftReport
set helpfile=info.%action%.txt
set args=/? /Action:%action%
set command=%tool% %args%
echo %command% > %helpfile%
echo %sep% >> %helpfile%
%command% >> %helpfile%

echo on