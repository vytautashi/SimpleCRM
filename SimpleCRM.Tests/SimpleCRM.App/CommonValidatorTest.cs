using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCRM.App.Validators;
using SimpleCRM.Data.Models;

namespace Tests.SimpleCRM.App
{
    [TestClass]
    public class CommonValidatorTests
    {
        [TestMethod]
        public void ValidateName_RequiredNameLengthValid_True()
        {
            string name = "Antanas";

            Assert.IsTrue(CommonValidator.ValidateName(name, true));
        }
        [TestMethod]
        public void ValidateName_RequiredNameLengthValid_False()
        {
            string name = "To";

            Assert.IsFalse(CommonValidator.ValidateName(name, true));
        }
        [TestMethod]
        public void ValidateName_RequiredNameLengthLongValid_False()
        {
            string name = "AntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanasAntanas";

            Assert.IsFalse(CommonValidator.ValidateName(name, true));
        }

        [TestMethod]
        public void ValidatePhone_Required_True()
        {
            string phoneNumber = "+124234235";

            Assert.IsTrue(CommonValidator.ValidatePhone(phoneNumber, true));
        }
        [TestMethod]
        public void ValidatePhone_Required_False()
        {
            string phoneNumber = "+124d234235";

            Assert.IsFalse(CommonValidator.ValidatePhone(phoneNumber, true));
        }
        [TestMethod]
        public void ValidatePhone_NotRequired_True()
        {
            string phoneNumber = "";

            Assert.IsTrue(CommonValidator.ValidatePhone(phoneNumber, false));
        }
        [TestMethod]
        public void ValidatePhone_NotRequired_False()
        {
            string phoneNumber = "ss";

            Assert.IsFalse(CommonValidator.ValidatePhone(phoneNumber, false));
        }
    }
}
