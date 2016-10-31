using Microsoft.Win32;
using System.Collections.Generic;

namespace CloneRegistry
{
    public class RegistryUpdater
    {
        public void CloneRegistry(string regKeySource, string regKeyDestination)
        {
            RegistryKey sourceKey = regKeySource.ParseRegistryKey();
            RegistryKey destinationKey = regKeyDestination.ParseRegistryKey();
            sourceKey.CopyTo(destinationKey);
        }

        public void UpdateRegistry(string settingsFile)
        {
            var csReader = new CloneSettingsReader(settingsFile);
            List<CopyData> copyDataList = csReader.GetCopyData();

            foreach (CopyData copyData in copyDataList)
            {
                CloneRegistry(copyData.SourceKey, copyData.DestinationKey);
            }

            List<UpdateData> updateDataList = csReader.GetUpdateData();
            foreach (UpdateData updateData in updateDataList)
            {
                Registry.SetValue(updateData.KeyName, updateData.ValueName, updateData.Value);
            }
        }
    }
}
