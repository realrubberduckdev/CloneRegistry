using CloneRegistry;
using Microsoft.Win32;
using NUnit.Framework;

namespace TestCloneRegistry
{
    [TestFixture]
    public class TestStringExtensions
    {
        [Test]
        public void TestParseRegistryKey()
        {
            string someString = "";
            RegistryKey keyValueFromString = someString.ParseRegistryKey();
            Assert.That(keyValueFromString, Is.Not.Null);
        }
    }
}
