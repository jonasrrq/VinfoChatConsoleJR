using System.Collections.Generic;
using System.Linq;

namespace VinfoChatConsole
{
    public class Mediator : IMediator
    {
        private readonly List<User> _users = new List<User>();
        public Mediator()
        {

        }

        public void RegisterUser(User user)
        {
            bool userExists = _users.Where(x => x == user).Any();
            if (!userExists)
            {
                _users.Add(user);
            }
        }
    }
}
