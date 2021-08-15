using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Brazil.Standard.Test
{
    [TestClass]
    public class CnpjTest
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException(string text)
        {
            new Cnpj(text);
            Assert.Fail("ArgumentException");
        }

        [DataTestMethod]
        [DataRow("1234567890123")]
        [DataRow("87.517.908/0001-552")]
        [ExpectedException(typeof(FormatException))]
        public void FormatException(string text)
        {
            new Cnpj(text);
            Assert.Fail("FormatException");
        }

        [DataTestMethod]
        [DataRow("60586932000191")]
        [DataRow("60.586.932/0001-91")]
        [ExpectedException(typeof(InvalidValueException))]
        public void InvalidValueException(string text)
        {
            new Cnpj(text);
            Assert.Fail("InvalidValueException");
        }

        [DataTestMethod]
        [DataRow("00461558000174", "00.461.558/0001-74")]
        [DataRow("68754677000159", "68.754.677/0001-59")]
        [DataRow("40938310000176", "40.938.310/0001-76")]
        public void Formatted(string text, string textFormatted)
        {
            Assert.AreEqual(textFormatted, new Cnpj(text).Formatted);
        }

        [DataTestMethod]
        [DataRow(461558000174U, "00.461.558/0001-74")]
        [DataRow(68754677000159U, "68.754.677/0001-59")]
        [DataRow(40938310000176U, "40.938.310/0001-76")]
        public void Value(ulong expected, string text)
        {
            Assert.AreEqual(expected, new Cnpj(text).Value);
        }
    }
}
