using CloneRegistry;
using Microsoft.Win32;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace TestCloneRegistry
{
    [TestFixture]
    public class TestStringExtensions
    {
        [TestCase(null)]
        [Description("Test that null input throws NRE.")]
        public void TestParseRegistryKeyNRE(string inputString)
        {
            Assert.Throws<NullReferenceException>(() => inputString.ParseRegistryKey());
        }

        [TestCase("")]
        [TestCase("RandomValue")]
        [Description("Test that invalid input throws exception.")]
        public void TestParseRegistryKeyNREException(string inputString)
        {
            ActualValueDelegate<RegistryKey> testDelegate = () => inputString.ParseRegistryKey();
            Assert.That(testDelegate, Throws.TypeOf<Exception>());
            //TODO: This should be a more specific exception. Fix code and update test.
        }

        [TestCase(@"HKEY_CLASSES_ROOT\*")]
        [TestCase(@"HKEY_CLASSES_ROOT\.386")]
        [TestCase(@"HKEY_CURRENT_USER\AppEvents")]
        [TestCase(@"HKEY_LOCAL_MACHINE\BCD00000000")]
        [TestCase(@"HKEY_USERS\S-1-5-18")]
        [TestCase(@"HKEY_USERS\.DEFAULT")]
        [TestCase(@"HKEY_CURRENT_CONFIG\System")]
        [Description("Test that we get the expected value for provided input from ParseRegistryKey method.")]
        public void TestParseRegistryKey(string inputString)
        {
            RegistryKey keyValueFromString = inputString.ParseRegistryKey();
            Assert.That(keyValueFromString, Is.Not.Null);

            string obtainedKeyInString = keyValueFromString.ToString();
            Assert.That(obtainedKeyInString, Is.EqualTo(inputString), "Invalid value for registry key obtained.");
        }
    }
}
