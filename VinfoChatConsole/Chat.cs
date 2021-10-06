using System;
using System.Collections.Generic;
using System.Linq;

namespace VinfoChatConsole
{
    public class Chat
    {
        private static IMediator mediator;
        private static List<User> users;
        public static void Init()
        {
            mediator = new Mediator();

            users = new List<User>
            {
                new ConecteUser(mediator, "@Alfonso"),
                new ConecteUser(mediator, "@Ivan"),
                new ConecteUser(mediator, "@Alicia")
            };

            foreach (User user in users)
            {
                mediator.RegisterUser(user);
            }
        }

        public static string Commands(string result)
        {
            string messagereturn = string.Empty;
            List<string> commandValidator = new List<string> { "post", "follow", "dashboard", "wall" };

            string[] results = result.Split(' ');
            if (results.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                messagereturn = "Parametros no Validos";
                Console.WriteLine(messagereturn);
            }
            else if (!commandValidator.Contains(results[0]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                messagereturn = "Comando no Valido";
                Console.WriteLine(messagereturn);
            }
            else
            {
                string comanmd = results[0];
                string userName = results[1];
                string message = results.Length >= 3 ? result.Replace($"{comanmd} {userName} ", "") : string.Empty;
                string userFollow = results.Length == 3 ? (message.Substring(0, 1) == "@" ? message : string.Empty) : string.Empty;

                User user = users.Where(x => x.UserName().ToLower().Equals(userName.ToLower())).FirstOrDefault();

                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    messagereturn = "Usuario no existe";
                    Console.WriteLine(messagereturn);
                }
                else if (comanmd.ToLower() == "dashboard" || comanmd.ToLower() == "wall")
                {
                    user.Dashboard();
                }
                else if (userFollow != string.Empty && comanmd.ToLower() == "follow")
                {
                    User userFollows = users.Where(x => x.UserName().ToLower().Equals(userFollow.ToLower())).FirstOrDefault();
                    if (userFollows == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        messagereturn = "Usuario a seguir no existe";
                        Console.WriteLine(messagereturn);
                    }
                    else
                    {
                        user.Follow(userFollows);
                    }

                }
                else if (comanmd.ToLower() == "post" && !string.IsNullOrEmpty(message))
                {
                    user.Post(message);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    messagereturn = "Debe escribir un mensaje";
                    Console.WriteLine(messagereturn);
                }
            }
            return messagereturn;

        }
    }
}
