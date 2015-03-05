@ECHO OFF
SET "CurDir=%~dp0"

SET "UnitTestFileName=%CurDir%bin\Debug\UnitTestDemo.dll"
SET "CoverageReportName=CodeCoverage.xml"

FOR %%I IN ("%UnitTestFileName%") DO SET "UnitTestAssembly=%%~nI"
FOR /f "tokens=2-4 delims=/ " %%a in ('date /t') do (SET RUNDATE=%%c-%%a-%%b)
FOR /f "tokens=1-2 delims=/:" %%a in ('time /t') do (SET RUNTIME=%%a-%%b)

IF NOT "%~1" == "" (
	SET "ReportDirectory=%~1"
) ELSE (
	SET "ReportDirectory=%CurDir%CoverageReports\%RUNDATE%_%RUNTIME%"
)

SET "ReportIndex=%ReportDirectory%\index.htm"

SET "XUnitConsolePath=%CurDir%packages\xunit.runners.2.0.0-rc3-build2880\tools\xunit.console.exe"
SET "OpenCoverPath=%CurDir%packages\OpenCover.4.5.3723\OpenCover.Console.exe"
SET "ReportGeneratorPath=%CurDir%packages\ReportGenerator.2.1.1.0\ReportGenerator.exe"

:: Some explanations:
:: -register:user
:: OpenCover uses a the .NET Framework's COM-based extensibility to profile
:: the code. This switch tells OpenCover to register this COM library for the
:: duration of the run. Since global COM  registration requires elevated
:: privileges, the 'user' bit tells it to register it in the HKEY_CURRENT_USER
:: hive (does NOT need elevation).
::
:: -output:<file path>
:: The results of the coverage pass
::
:: -target:<file path>
:: The executable that will be run for the pass
::
:: -targetdir:<folder path>
:: The working directory (used for finding PDBs).
::
:: -targetargs:""<arguments>""
:: The arguments passed to the target. Since we're using XUnit, this
:: will be a path to the unit test assembly.
::
:: -filter:<filter expressions>
:: An expression telling OpenCover what assemblies/classes to include in
:: its analysis. It uses a +/-[<AssemblyNameExpression>]<ClassNameExpression>
:: format that supports wildcard globbing.
::
"%OpenCoverPath%" -register:user "-output:%CoverageReportName%" "-target:%XUnitConsolePath%" "-targetdir:%CurDir%bin\Debug" "-targetargs:""%UnitTestFileName%""" "-filter:+[*]* -[xunit*]* -[%UnitTestAssembly%]*"
IF NOT ERRORLEVEL 0 (
	ECHO Unable to perform code coverage - Error %ERRORLEVEL%.
	SET RESULT=-1
	GOTO END
)
::
:: Generate a nicely-formatted set of HTML documents with the results
::
"%ReportGeneratorPath%" "-reports:%CoverageReportName%" "-targetdir:%ReportDirectory%"
IF NOT ERRORLEVEL 0 (
	ECHO Unable to generate report - Error %ERRORLEVEL%.
	SET RESULT=-2
	GOTO END
)

SET RESULT=0
IF "%~1" == "-show" SET ShowReport=1
IF "%~2" == "-show" SET ShowReport=1
IF "%~3" == "-show" SET ShowReport=1
IF "%~4" == "-show" SET ShowReport=1
IF "%~5" == "-show" SET ShowReport=1

IF "ShowReport" == "1" (
  :: Launch the default browser to open the report
  "%ReportIndex%"
) ELSE (
  ECHO Code coverage report: "%ReportIndex%"
)
:END
EXIT /B %RESULT%