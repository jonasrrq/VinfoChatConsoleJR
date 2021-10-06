using System;
using System.Collections.Generic;
using System.Linq;

namespace VinfoChatConsole
{
    public class ConecteUser : User
    {
        private List<User> usersNameFollow = new List<User>();
        public ConecteUser(IMediator mediator, string userName) : base(mediator, userName)
        {
        }

        public override void Dashboard()
        {
            foreach (var user in this.usersNameFollow)
            {
                foreach (var post in user.Posts())
                {
                    Console.WriteLine($"\t{post.UserName.Replace("@", "")} posted -> \"{post.Message}\" { $"@{post.Date:hh:mm:ss}"}");
                }                
            }
        }

        public override void Follow(User user)
        {
            bool userExists = usersNameFollow.Where(x => x.Equals(user.UserName())).Any();
            if (!userExists)
            {
                this.usersNameFollow.Add(user);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\t{this.userName.Replace("@", "")} empezó a seguir a > {user.UserName()}");
            }
        }

        public override void Post(string message)
        {
            Post post = new Post { UserName = userName, Message = message, Date = DateTime.Now};
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t{post.UserName.Replace("@","")} posted -> \"{post.Message}\" { $"@{post.Date:hh:mm:ss}"}");
            posts.Add(post);
            //Mediator.SendMessage(this, message);
        }
    }
}
