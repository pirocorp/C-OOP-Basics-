namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviousPage = 11,
            NextPage = 12,
        }

        public int CurrentPage { get ; set ; }

        private string[] PostTitles { get; set; }

        private int LastPage => this.PostTitles.Length / PAGE_OFFSET + 1;

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CategoryId { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            throw new NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
