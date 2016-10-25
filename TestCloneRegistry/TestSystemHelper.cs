using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
