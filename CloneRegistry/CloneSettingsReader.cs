using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CloneRegistry
{
    public class CloneSettingsReader
    {
        XmlDocument _xmlDocument;

        public CloneSettingsReader(string settingsFile)
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(settingsFile);
        }

        public List<CopyData> GetCopyData()
        {
            List<CopyData> copyDataList = new List<CopyData>();

            XmlNode cloneRegistryNode = _xmlDocument.FirstChild;
            XmlNodeList copyTags;
            copyTags = _xmlDocument.GetElementsByTagName("Copy");

            //Change the price on the books.
            foreach (XmlNode copyTag in copyTags)
            {
                var copyData = new CopyData();
                copyData.SourceKey = copyTag.Attributes["SourceKey"].Value;
                copyData.DestinationKey = copyTag.Attributes["DestinationKey"].Value;
                copyDataList.Add(copyData);
            }
            return copyDataList;
        }
    }

    public struct CopyData
    {
        public string SourceKey;
        public string DestinationKey;
    }
}
