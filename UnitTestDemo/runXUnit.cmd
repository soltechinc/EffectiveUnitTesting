@echo off
SET "CurDur=%~dp0"
for /d %%i in ("%CurDur%packages\xunit.runners.2.0.0*") do (
	for %%j in ("%%i\tools\xunit.console.exe") do set "XUnitPath=%%j"
)
%XUnitPath% %*
