﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            string regKeySource = args[0];
            string regKeyDestination = args[1];

            RegistryKey sourceKey = regKeySource.ParseRegsitryKey();
            RegistryKey destinationKey = regKeyDestination.ParseRegsitryKey();
            sourceKey.CopyTo(destinationKey);
        }
    }
}
