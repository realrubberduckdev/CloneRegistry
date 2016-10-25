using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace CloneRegistry
{
    class Program
    {
        private static RegistryUpdater _registryUpdater = new RegistryUpdater();

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                ShowUsage();
                return;
            }

            if (args[0].Equals(@"/s", StringComparison.InvariantCultureIgnoreCase))
            {
                _registryUpdater.UpdateRegistry(args[1]);
            }
            else
            {
                string regKeySource = args[0];
                string regKeyDestination = args[1];
                _registryUpdater.CloneRegistry(regKeySource, regKeyDestination);
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Examples:");
            Console.WriteLine(@"CloneRegistry.exe ""HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node"" ""HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node_Backup""");
            Console.WriteLine(@"CloneRegistry.exe /s settings.xml");
        }
    }
}
