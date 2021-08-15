using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Brazil.Standard.Test
{
    [TestClass]
    public class CpfTest
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException(string text)
        {
            new Cpf(text);
            Assert.Fail("ArgumentException");
        }

        [DataTestMethod]
        [DataRow("123456789")]
        [DataRow("832.973.730-672")]
        [ExpectedException(typeof(FormatException))]
        public void FormatException(string text)
        {
            new Cpf(text);
            Assert.Fail("FormatException");
        }

        [DataTestMethod]
        [DataRow("44433322211")]
        [DataRow("444.333.222-11")]
        [ExpectedException(typeof(InvalidValueException))]
        public void InvalidValueException(string text)
        {
            new Cpf(text);
            Assert.Fail("InvalidValueException");
        }

        [DataTestMethod]
        [DataRow("83297373067", "832.973.730-67")]
        [DataRow("59202906092", "592.029.060-92")]
        [DataRow("19105217016", "191.052.170-16")]
        public void Formatted(string text, string textFormatted)
        {
            Assert.AreEqual(textFormatted, new Cpf(text).Formatted);
        }

        [DataTestMethod]
        [DataRow(83297373067U, "832.973.730-67")]
        [DataRow(59202906092U, "592.029.060-92")]
        [DataRow(7259678461U, "072.596.784-61")]
        public void Value(ulong expected, string text)
        {
            Assert.AreEqual(expected, new Cpf(text).Value);
        }
    }
}
