using CloneRegistry;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace TestCloneRegistry
{
    [TestFixture]
    public class TestCloneSettingsReader
    {
        string _testDataPath;
        string _settingsFilePath;

        [OneTimeSetUp]
        public void FixtureOneTimeSetup()
        {
            _testDataPath = TestSystemHelper.GetTestDataPath("TestCloneSettingsReader");
            _settingsFilePath = Path.Combine(_testDataPath, "settings.xml");
        }

        [Test]
        [Description("Test that we get expected registry key in strings from the provided xml.")]
        public void TestGetCopyData()
        {
            List<CopyData> expectedCopyDataList = new List<CopyData>();
            expectedCopyDataList.Add(new CopyData()
            {
                SourceKey = @"HKEY_CURRENT_USER\Console",
                DestinationKey = @"HKEY_CURRENT_USER\ConsoleBackup"
            });
            expectedCopyDataList.Add(new CopyData()
            {
                SourceKey = @"HKEY_CURRENT_USER\Environment",
                DestinationKey = @"HKEY_CURRENT_USER\EnvironmentBackup"
            });

            var csReader = new CloneSettingsReader(_settingsFilePath);
            List<CopyData> copyDataList = csReader.GetCopyData();

            Assert.That(copyDataList, Is.EqualTo(expectedCopyDataList), "GetCopyData incorrect CopyData list.");
        }

        [Test]
        [Description("Test that we get expected registry key in strings from the provided xml.")]
        public void TestGetUpdateData()
        {
            List<UpdateData> expectedUpdateDataList = new List<UpdateData>();
            expectedUpdateDataList.Add(new UpdateData()
            {
                KeyName = @"HKEY_CURRENT_USER\dpTempBackup",
                ValueName = @"someVar",
                Value = "2"
            });

            var csReader = new CloneSettingsReader(_settingsFilePath);
            List<UpdateData> updateDataList = csReader.GetUpdateData();

            Assert.That(updateDataList, Is.EqualTo(expectedUpdateDataList), "GetCopyData incorrect UpdateData list.");
        }
    }
}
