# CloneRegistry
[![AppVeyor Build status](https://ci.appveyor.com/api/projects/status/3xfkxtnkrts1x06q/branch/master?svg=true)](https://ci.appveyor.com/project/dp7g09/cloneregistry/branch/master)

# Description
Tool to easily clone a registry hive into another.

# Uses of the tool
* In some instances, for testing, we will need to create machines and clone some existing registry keys and re-enter them with updated values. CloneRegistry can do that with a config file or parameters.
* ...add more.

# Example
You will need to publish the tool first to get the exe (check below for how to).
CloneRegistry.exe "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node" "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node_Backup"
Copies all keys to the new Backup one.

CloneRegistry.exe /s settings.xml
This can copy and update keys.
Check template in solution for xml format.

Without the exe you can still run it as a dotnet core application as follows:
CloneRegistry\CloneRegistry>dotnet run --project CloneRegistry.csproj

# For buiding solution
Either open solution in Visual Studio and build it.
Or from Visual Studio command prompt:
CloneRegistry>dotnet build CloneRegistry.sln

# For Publishing the tool
CloneRegistry\CloneRegistry>dotnet publish -c Release -r win10-x64 CloneRegistry.csproj
This will generate CloneRegistry.exe at CloneRegistry\bin\Release\netcoreapp2.1\win10-x64\publish\

# For running tests
CloneRegistry\TestCloneRegistry>dotnet test TestCloneRegistry.csproj
