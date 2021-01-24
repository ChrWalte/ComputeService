using ComputeService.v1.Shared;
using NUnit.Framework;

namespace ComputeService.Tests.Shared
{
    internal class UtilitiesTests
    {
        [Test]
        [TestCase("", "", "", "")]
        [TestCase("data", "salt", "pepper", "saltdatapepper")]
        public void ApplySaltAndPepperTests(string data, string salt, string pepper, string expected)
        {
            var actual = Utilities.ApplySaltAndPepper(data, salt, pepper);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", "", "")]
        [TestCase("data", "salt", "saltdata")]
        public void ApplySaltTests(string data, string salt, string expected)
        {
            var actual = Utilities.ApplySalt(data, salt);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", "", "")]
        [TestCase("data", "pepper", "datapepper")]
        public void ApplyPepperTests(string data, string pepper, string expected)
        {
            var actual = Utilities.ApplyPepper(data, pepper); 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", new byte[] {})]
        [TestCase("a", new byte[] { 97 })]
        [TestCase("ab", new byte[] { 97, 98})]
        public void StringToBytesTests(string data, byte[] expected)
        {
            var actual = Utilities.StringToBytes(data);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new byte[] { }, "")]
        [TestCase(new byte[] { 97 }, "a")]
        [TestCase(new byte[] { 97, 98 }, "ab")]
        public void BytesToStringTests(byte[] data, string expected)
        {
            var actual = Utilities.BytesToString(data);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new byte[] { }, "")]
        [TestCase(new byte[] { 97 }, "61")]
        [TestCase(new byte[] { 97, 98 }, "6162")]
        public void HashBytesToStringTests(byte[] data, string expected)
        {
            var actual = Utilities.HashBytesToString(data);
            Assert.AreEqual(expected, actual);
        }
    }
}
