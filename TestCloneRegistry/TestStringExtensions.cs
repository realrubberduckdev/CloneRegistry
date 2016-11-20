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
    }
}
