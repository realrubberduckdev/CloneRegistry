using Microsoft.Win32;
using System;

namespace CloneRegistry
{
    public static class StringExtensions
    {
        public static RegistryKey ParseRegistryKey(this string regKeyFullPath)
        {
            const string HKEY_LOCAL_MACHINE = "HKEY_LOCAL_MACHINE";
            const string HKEY_CLASSES_ROOT = "HKEY_CLASSES_ROOT";
            const string HKEY_CURRENT_USER = "HKEY_CURRENT_USER";
            const string HKEY_USERS = "HKEY_USERS";
            const string HKEY_CURRENT_CONFIG = "HKEY_CURRENT_CONFIG";

            RegistryKey regKey = null;
            if (regKeyFullPath.StartsWith(HKEY_LOCAL_MACHINE, StringComparison.InvariantCultureIgnoreCase))
            {
                string regKeyRelativePath = regKeyFullPath.Substring(HKEY_LOCAL_MACHINE.Length + 1);
                regKey = GetRegistryKey(RegistryHive.LocalMachine, regKeyRelativePath);
            }
            else if (regKeyFullPath.StartsWith(HKEY_CLASSES_ROOT, StringComparison.InvariantCultureIgnoreCase))
            {
                string regKeyRelativePath = regKeyFullPath.Substring(HKEY_CLASSES_ROOT.Length + 1);
                regKey = GetRegistryKey(RegistryHive.ClassesRoot, regKeyRelativePath);
            }
            else if (regKeyFullPath.StartsWith(HKEY_CURRENT_USER, StringComparison.InvariantCultureIgnoreCase))
            {
                string regKeyRelativePath = regKeyFullPath.Substring(HKEY_CURRENT_USER.Length + 1);
                regKey = GetRegistryKey(RegistryHive.CurrentUser, regKeyRelativePath);
            }
            else if (regKeyFullPath.StartsWith(HKEY_USERS, StringComparison.InvariantCultureIgnoreCase))
            {
                string regKeyRelativePath = regKeyFullPath.Substring(HKEY_USERS.Length + 1);
                regKey = GetRegistryKey(RegistryHive.Users, regKeyRelativePath);
            }
            else if (regKeyFullPath.StartsWith(HKEY_CURRENT_CONFIG, StringComparison.InvariantCultureIgnoreCase))
            {
                string regKeyRelativePath = regKeyFullPath.Substring(HKEY_CURRENT_CONFIG.Length + 1);
                regKey = GetRegistryKey(RegistryHive.CurrentConfig, regKeyRelativePath);
            }
            else
            {
                throw new Exception("Invalid registry key string obtained. It should start with something similar to HKEY_LOCAL_MACHINE etc.");
            }

            return regKey;
        }

        private static RegistryKey GetRegistryKey(RegistryHive registryHive, string regKeyRelativePath)
        {
            RegistryKey baseRegKey = RegistryKey.OpenBaseKey(registryHive, RegistryView.Registry64);
            RegistryKey regKey = baseRegKey.CreateSubKey(regKeyRelativePath);
            return regKey;
        }
    }
}
