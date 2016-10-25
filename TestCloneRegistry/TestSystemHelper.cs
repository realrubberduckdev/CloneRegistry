using System;
using System.IO;

namespace TestCloneRegistry
{
    public class TestSystemHelper
    {
        public static string GetTestDataPath(string testName)
        {
            string crHomePath = Environment.GetEnvironmentVariable("CRHOME");
            string testDataPath = Path.Combine(crHomePath, "TestCloneRegistry", "TestData", testName);
            return testDataPath;
        }
    }
}
