using System;
using System.IO;

namespace TestCloneRegistry
{
    /// <summary>
    /// Helper methods, constants etc for tests should go in this class.
    /// </summary>
    public class TestSystemHelper
    {
        /// <summary>
        /// Helps tests get a location where they can use already stored data
        /// to be used for testing.
        /// </summary>
        /// <param name="testName"></param>
        /// <returns></returns>
        public static string GetTestDataPath(string testName)
        {
            string testDataPath = Path.Combine("TestData", testName);
            return testDataPath;
        }
    }
}
