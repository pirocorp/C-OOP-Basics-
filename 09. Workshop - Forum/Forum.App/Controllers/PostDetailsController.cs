namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;


    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser { get; set; }

        public int PostId { get; private set; }

        private enum Command
        {
            Back,
            AddReplay
        }

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void UserLogIn()
        {
            throw new System.NotImplementedException();
        }

        public void UserLogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}