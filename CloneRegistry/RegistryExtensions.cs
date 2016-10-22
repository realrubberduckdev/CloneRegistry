﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneRegistry
{
    /// <summary>
    /// Contains extension methods for <see cref="Registry"/>
    /// </summary>
    public static class RegistryExtensions
    {
        /// <summary>
        /// Copy one hive of registry keys into another
        /// </summary>
        /// <param name="sourceKey"></param>
        /// <param name="destinationKey"></param>
        public static void CopyTo(this RegistryKey sourceKey, RegistryKey destinationKey)
        {
            // copy the values
            foreach (var name in sourceKey.GetValueNames())
            {
                destinationKey.SetValue(name, sourceKey.GetValue(name), sourceKey.GetValueKind(name));
            }

            // copy the subkeys
            foreach (var name in sourceKey.GetSubKeyNames())
            {
                using (var srcSubKey = sourceKey.OpenSubKey(name, false))
                {
                    var dstSubKey = destinationKey.CreateSubKey(name);
                    srcSubKey.CopyTo(dstSubKey);
                }
            }
        }
    }
}
