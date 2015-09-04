@echo off

set conn=Connection-Name-Here
set host=Hostname/IP-Here
set lpsk=pre-shared-key

set user=username-here
set pass=password-here

set exec=pskvpn.exe

%exec% %conn% %host% %lpsk%
rasdial %conn% %user% %pass%

pause
