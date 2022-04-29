using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Course_Work;

namespace UnitTest
{
    [TestClass]
    public class KeyValidationTest
    {
        [TestMethod]
        public void KeyValidationTest_WithNumbers()
        {
            string key = "42";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void KeyValidationTest_Nothing()
        {
            string key = "";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void KeyValidationTest_normal()
        {
            string key = "ключ";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void KeyValidationTest_English()
        {
            string key = "TARDIS";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void KeyValidationTest_NotLetter()
        {
            string key = "@#$%^&";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void KeyValidationTest_Space()
        {
            string key = "42";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void KeyValidationTest_CapitalLetters()
        {
            string key = "КлЮч";
            bool result = MainWindow.KeyValidation(key);

            Assert.AreEqual(result, true);
        }
    }
}
