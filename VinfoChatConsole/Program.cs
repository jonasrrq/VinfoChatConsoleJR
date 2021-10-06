using System;

namespace VinfoChatConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Chat.Init();
            Console.WriteLine("VinfoChatConsole => Exit para Salir");
            bool exit;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                string result = Console.ReadLine();

                exit = result.ToUpperInvariant() == "EXIT";

                Chat.Commands(result);

            } while (!exit);
        }
    }
}
