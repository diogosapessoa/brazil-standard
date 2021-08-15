using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brazil.Standard.Extensions.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        [DataTestMethod]
        [DataRow("teste", "$t;e%s-t~e")]
        [DataRow("TestE123", "#TestE@123_")]
        public void OnlyAlphaNumeric(string expected, string text)
        {
            Assert.AreEqual(expected, text.OnlyAlphaNumeric());
        }

        [DataTestMethod]
        [DataRow("123", "123ABC")]
        [DataRow("123", "#TestE@123_")]
        [DataRow("12345678900", "123.456.789-00")]
        [DataRow("12994203000120", "12.994.203/0001-20")]
        public void OnlyDigits(string expected, string text)
        {
            Assert.AreEqual(expected, text.OnlyDigits());
        }

        [DataTestMethod]
        [DataRow("452.593.190-60")]
        [DataRow("435.322.600-26")]
        [DataRow("187.224.870-50")]
        [DataRow("229.231.410-08")]
        public void CpfValid(string text)
        {
            Assert.IsTrue(text.IsCpfValid());
        }

        [DataTestMethod]
        [DataRow("000.000.000-00")]
        [DataRow("999.999.999-99")]
        [DataRow("123.456.789-00")]
        public void CpfInvalid(string text)
        {
            Assert.IsFalse(text.IsCpfValid());
        }

        [DataTestMethod]
        [DataRow("33.312.259/0001-27")]
        [DataRow("06.194.827/0001-60")]
        [DataRow("85.906.324/0001-46")]
        public void CnpjValid(string text)
        {
            Assert.IsTrue(text.IsCnpjValid());
        }

        [DataTestMethod]
        [DataRow("33.312.259/0001-28")]
        [DataRow("06.194.827/0001-61")]
        [DataRow("85.906.324/0001-47")]
        public void CnpjInvalid(string text)
        {
            Assert.IsFalse(text.IsCnpjValid());
        }
    }
}
