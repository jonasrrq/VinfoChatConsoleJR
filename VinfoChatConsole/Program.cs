using System;
using System.Collections.Generic;
using System.Linq;

namespace VinfoChatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IMediator mediator = new Mediator();
            List<User> users = new List<User>
            {
                new ConecteUser(mediator, "@Alfonso"),
                new ConecteUser(mediator, "@Ivan"),
                new ConecteUser(mediator, "@Alicia")
            };

            foreach (User user in users)
            {
                mediator.RegisterUser(user);
            }

            Console.WriteLine("VinfoChatConsole => Exit para Salir");
            bool exit;
            List<string> commandValidator = new List<string> { "post", "follow", "dashboard", "wall" };
            // string expresionUserText = @"\@(.* )";
            // Regex r = new Regex(expresionUserText, RegexOptions.IgnoreCase);
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                string result = Console.ReadLine();
                // Match x = r.Match(result);

                exit = result.ToUpperInvariant() == "EXIT";

                string[] results = result.Split(' ');
                if (results.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Parametros no Validos");
                }
                else if (!commandValidator.Contains(results[0]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Comando no Valido");
                }
                else
                {
                    string comanmd = results[0];
                    string userName = results[1];
                    string message = result.Replace($"{comanmd} {userName} ", "");
                    string userFollow = message.Substring(0, 1) == "@" ? message : string.Empty;

                    User user = users.Where(x => x.UserName().ToLower().Equals(userName.ToLower())).FirstOrDefault();

                    if (user == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Usuario no existe");
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
                            Console.WriteLine("Usuario a seguir no existe");
                        }
                        else
                        {
                            user.Follow(userFollows);
                        }
                       
                    }
                    else if (comanmd.ToLower() == "post")
                    {
                        user.Post(message);
                    }
                }

            } while (!exit);
        }
    }
}
