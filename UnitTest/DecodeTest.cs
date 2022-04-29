using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Course_Work;

namespace UnitTest
{
    [TestClass]
    public class DecodeTest
    {
        [TestMethod]
        public void DecodeTest_WithNumbers()
        {
            string text = "Юбнуе тн щрпрщйь жьёхюа тчътц, шцфърьауч я жбуоэ еешезю - 42";
            string key = "полотенце";
            string expected = "Ответ на главный вопрос жизни, вселенной и всего такого - 42";
            var message = new Message(text, key);

            string actual = message.Decode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecodeTest_English()
        {
            string text = "Don't Panic!";
            string key = "путеводитель";
            string expected = "Don't Panic!";
            var message = new Message(text, key);

            string actual = message.Decode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecodeTest_Nothing()
        {
            string text = "";
            string key = "пустота";
            string expected = "";
            var message = new Message(text, key);

            string actual = message.Decode();

            Assert.AreEqual(expected, actual);
        }
    }
}
