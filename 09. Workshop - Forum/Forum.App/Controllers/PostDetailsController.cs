namespace Forum.App.Controllers
{
    using System;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Services;
    using UserInterface;
    using Views;


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
            switch ((Command)index)
            {
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                case Command.AddReplay:
                    return MenuState.AddReplyToPost;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            var postViewModel = PostService.GetPostViewModel(this.PostId);
            return new PostDetailsView(postViewModel, this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }
    }
}