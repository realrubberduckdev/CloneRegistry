@echo off
rem Clone Registry (CR) environment setup
set CRHOME=%cd%

rem NUNIT_HOME is created during build process
set NUNIT_HOME=%CRHOME%\packages\NUnit.3.10.1\lib\net45

set NUGET_HOME=%cd%\CRNuGet
set PATH=%NUNIT_HOME%;%NUGET_HOME%;%PATH%

echo Setenv finished.