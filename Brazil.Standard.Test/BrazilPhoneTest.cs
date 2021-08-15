using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Brazil.Standard.Test
{
    [TestClass]
    public class BrazilPhoneTest
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException(string text)
        {
            new BrazilPhone(text);
            Assert.Fail("ArgumentException");
        }

        [DataTestMethod]
        [DataRow("123")]
        [DataRow("996942822")]
        [DataRow("35073033")]
        [DataRow("+558341996942822")]
        [DataRow("+55834135073033")]
        [ExpectedException(typeof(FormatException))]
        public void FormatException(string text)
        {
            new BrazilPhone(text);
            Assert.Fail("FormatException");
        }

        [DataTestMethod]
        [DataRow("+5583996942822", "(83)99694-2822")]
        [DataRow("83996942822", "(83)99694-2822")]
        public void Formatted(string text, string textFormatted)
        {
            Assert.AreEqual(textFormatted, new BrazilPhone(text).Formatted);
        }

        [DataTestMethod]
        [DataRow("(83)99694-2822", "+5583996942822")]
        [DataRow("83996942822", "+5583996942822")]
        public void International(string text, string expected)
        {
            Assert.AreEqual(expected, new BrazilPhone(text).International);
        }

        [DataTestMethod]
        [DataRow("+5583996942822", 83996942822U)]
        [DataRow("(83)99694-2822", 83996942822U)]
        [DataRow("83996942822", 83996942822U)]
        public void Value(string text, ulong expected)
        {
            Assert.AreEqual(expected, new BrazilPhone(text).Value);
        }
    }
}
