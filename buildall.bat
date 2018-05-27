@echo off
call nuget.exe restore CloneRegistry.sln
msbuild CloneRegistry.sln