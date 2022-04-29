using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Course_Work;

namespace UnitTest
{
    [TestClass]
    public class EncodeTest
    {
        [TestMethod]
        public void EncodeTest_WithNumbers()
        {
            string text = "Ответ на главный вопрос жизни, вселенной и всего такого - 42";
            string key = "полотенце";
            string expected = "Юбнуе тн щрпрщйь жьёхюа тчътц, шцфърьауч я жбуоэ еешезю - 42";
            var message = new Message(text, key);

            string actual = message.Encode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EncodeTest_English()
        {
            string text = "Don't Panic!";
            string key = "путеводитель";
            string expected = "Don't Panic!";
            var message = new Message(text, key);

            string actual = message.Encode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EncodeTest_Nothing()
        {
            string text = "";
            string key = "пустота";
            string expected = "";
            var message = new Message(text, key);

            string actual = message.Encode();

            Assert.AreEqual(expected, actual);
        }
    }
}
