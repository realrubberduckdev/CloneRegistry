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
    }
}
