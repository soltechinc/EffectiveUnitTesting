@echo off
SET "CurDir=%~dp0"
for /d %%i in ("%CurDir%packages\xunit.runners.2.0.0*") do (
	for %%j in ("%%i\tools\xunit.console.exe") do set "XUnitPath=%%j"
)
%XUnitPath% %*
