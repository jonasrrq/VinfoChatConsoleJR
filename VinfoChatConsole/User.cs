using System.Collections.Generic;

namespace VinfoChatConsole
{
    public abstract class User 
    {
        protected IMediator Mediator;
        protected string userName = string.Empty;
        //protected List<string> usersNameFollow = new List<string>();
        protected List<Post> posts = new List<Post>();

        public User(IMediator mediator, string userName)
        {
            Mediator = mediator;
            this.userName = userName;
        }

        public abstract void Post(string message);

        public abstract void Dashboard();

        public abstract void Follow(User userName);

        public string UserName() => userName;  

        //public List<string> UsersNameFollow() => usersNameFollow;

        public List<Post> Posts() => posts;


        //{
        //   
        //}



    }
}
