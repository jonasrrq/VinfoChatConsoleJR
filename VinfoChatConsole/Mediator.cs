using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinfoChatConsole
{
    public class Mediator : IMediator
    {
        private List<User> _users = new List<User>();
        public Mediator()
        {

        }

        public void RegisterUser(User user)
        {
            bool userExists = _users.Where(x => x == user).Any();
            if (!userExists)
            {
                _users.Add(user);
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.WriteLine($"\t{this..Replace("@", "")} empezó a seguir a > {userName}");
            }
        }

        //public void SendMessage(User user, string message)
        //{
        //    //bool userExists = _users.Where(x => x == user).Any();
        //    //if (userExists)
        //    //{
        //        user.Post(message);
        //    //}
        //}
    }
}
