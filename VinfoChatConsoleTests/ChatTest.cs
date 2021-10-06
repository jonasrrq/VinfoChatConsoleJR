using Microsoft.VisualStudio.TestTools.UnitTesting;

using VinfoChatConsole;

namespace VinfoChatConsoleTests
{
    [TestClass]
    public class ChatTest
    {
        public ChatTest()
        {
            Chat.Init();
        }

        [TestMethod]
        public void ParametrosNoValidosSinAggumentos()
        {
            string result = Chat.Commands("");
            Assert.AreEqual("Parametros no Validos", result);
        }

        [TestMethod]
        public void ParametrosNoValidosUnAggumento()
        {
            string result = Chat.Commands("Hola");
            Assert.AreEqual("Parametros no Validos", result);
        }

        [TestMethod]
        public void ParametrosNoValidosDosAggumento()
        {
            string result = Chat.Commands("Hola @Alicia");
            Assert.AreEqual("Comando no Valido", result);
        }

        [TestMethod]
        public void UsuarioNoExiste()
        {
            string result = Chat.Commands("post @Alicias este es el mensaje");
            Assert.AreEqual("Usuario no existe", result);
        }

        [TestMethod]
        public void PostExitoso()
        {
            string result = Chat.Commands("post @Alicia este es el mensaje");
            Assert.AreNotEqual("Usuario no existe", result);
        }

        [TestMethod]
        public void DebeEscribirUnMensaje()
        {

            string result = Chat.Commands("post @Alicia");
            Assert.AreEqual("Debe escribir un mensaje", result);
        }

        [TestMethod]
        public void UsuarioASeguirNoExiste()
        {

            string result = Chat.Commands("follow @Alicia @Iva");
            Assert.AreEqual("Usuario a seguir no existe", result);
        }

        //"Usuario a seguir no existe"
    }
}

