namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using UserInterface.Input;
    using UserInterface.ViewModels;

    public class AddPostController : IController
    {
        private const int COMMAND_COUNT = 4;
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 18;
        private const int POST_MAX_LENGTH = 660;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        private enum Command
        {
            AddTitle,
            AddCategory,
            Write,
            Post,
        }

        public PostViewModel Post { get; private set; }

        private TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
