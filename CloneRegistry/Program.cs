using Microsoft.Win32;
using System;

namespace CloneRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                ShowUsage();
                return;
            }

            if (args[0].Equals(@"/s", StringComparison.InvariantCultureIgnoreCase))
            {
                CloneUsingSettings(args[1]);
            }
            else
            {
                string regKeySource = args[0];
                string regKeyDestination = args[1];

                RegistryKey sourceKey = regKeySource.ParseRegistryKey();
                RegistryKey destinationKey = regKeyDestination.ParseRegistryKey();
                sourceKey.CopyTo(destinationKey);
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Examples:");
            Console.WriteLine(@"CloneRegistry.exe ""HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node"" ""HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Wow6432Node_Backup""");
            Console.WriteLine(@"CloneRegistry.exe /s settings.xml");
        }

        private static void CloneUsingSettings(string settingsFile)
        {
            //dummy method
        }
    }
}
