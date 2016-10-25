﻿using System.Collections.Generic;
using System.Text;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(SourceKey:");
            sb.Append(SourceKey);
            sb.Append(",");
            sb.Append("DestinationKey:");
            sb.Append(DestinationKey);
            sb.Append(")");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            CopyData objCopyData = (CopyData)obj;
            if (objCopyData.SourceKey.Equals(SourceKey) && objCopyData.DestinationKey.Equals(DestinationKey))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
