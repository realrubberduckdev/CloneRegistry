# CloneRegistry
Tool to easily clone a registry hive into another.

#Uses of the tool
* The team I work in, needs to create machines and clone some existing registry keys and re-enter them with updated values. CloneRegistry is on path to do that with a config file.
* ...add more.

# Example
CloneRegistry.exe "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node" "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node_Backup"
Copies all keys to the new Backup one.

# For buiding solution
From visual studio prompt call setenv.bat.
Msbuild the sln file.

#For running tests
From the build prompt call testit.bat. It will create TestResult.xml at root folder.