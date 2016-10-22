using Microsoft.Win32;

namespace CloneRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            string regKeySource = args[0];
            string regKeyDestination = args[1];

            RegistryKey sourceKey = regKeySource.ParseRegistryKey();
            RegistryKey destinationKey = regKeyDestination.ParseRegistryKey();
            sourceKey.CopyTo(destinationKey);
        }
    }
}
