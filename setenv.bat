@echo off
rem Clone Registry (CR) environment setup
set CRHOME=%cd%

rem NUNIT_HOME is created during build process
set NUNIT_TOOLS_HOME=%CRHOME%\packages\NUnit.ConsoleRunner.3.8.0\tools

set NUGET_HOME=%cd%\CRNuGet
set PATH=%NUNIT_HOME%;%NUGET_HOME%;%PATH%

if not exist "%NUNIT_TOOLS_HOME%\nunit3-console.exe" (
	call %NUGET_HOME%\nuget.exe restore CloneRegistry.sln
)

echo Setenv finished.