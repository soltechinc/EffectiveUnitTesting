@ECHO OFF
SET "CurDir=%~dp0"

SET "UnitTestFileName=%CurDir%bin\Debug\UnitTestDemo.dll"
SET "CoverageReportName=CodeCoverage.xml"

FOR %%I IN (%UnitTestFileName%) DO SET "UnitTestAssembly=%%~nI"
FOR /f "tokens=2-4 delims=/ " %%a in ('date /t') do (SET RUNDATE=%%c-%%a-%%b)
FOR /f "tokens=1-2 delims=/:" %%a in ('time /t') do (SET RUNTIME=%%a-%%b)
SET "ReportDirectory=%CurDir%Reports\%RUNDATE%_%RUNTIME%"
SET "ReportIndex=%ReportDirectory%\index.htm"

SET "XUnitConsolePath=%CurDir%packages\xunit.runners.2.0.0-rc3-build2880\tools\xunit.console.exe"
SET "OpenCoverPath=%CurDir%packages\OpenCover.4.5.3723\OpenCover.Console.exe"
SET "ReportGeneratorPath=%CurDir%packages\ReportGenerator.2.1.1.0\ReportGenerator.exe"

"%OpenCoverPath%" "-output:%CoverageReportName%" "-target:%XUnitConsolePath%" "-targetdir:%CurDir%bin\Debug" "-targetargs:""%UnitTestFileName%"" -noshadow" "-filter:+[*]* -[xunit*]* -[%UnitTestAssembly%]*"
IF NOT ERRORLEVEL 0 (
	ECHO Unable to perform code coverage - Error %ERRORLEVEL%.
	SET RESULT=-1
	GOTO END
)
"%ReportGeneratorPath%" "-reports:%CoverageReportName%" "-targetdir:%ReportDirectory%"
IF NOT ERRORLEVEL 0 (
	ECHO Unable to generate report - Error %ERRORLEVEL%.
	SET RESULT=-2
	GOTO END
)

SET RESULT=0
IF "%1" == "-show" (
  :: Launch the default browser to open the report
  "%ReportIndex%"
) ELSE (
  ECHO Code coverage report: "%ReportIndex%"
)
:END
EXIT /B %RESULT%