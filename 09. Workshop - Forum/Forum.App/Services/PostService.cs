namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Models;
    using UserInterface.ViewModels;

    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            var forumData = new ForumData();
            var category = forumData.Categories.Find(c => c.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            var forumData = new ForumData();

            var post = forumData.Posts.Find(p => p.Id == postId);

            var replies = new List<ReplyViewModel>();

            foreach (var replayId in post.ReplayIds)
            {
                var replay = forumData.Replies.Find(r => r.Id == replayId);
                replies.Add(new ReplyViewModel(replay));
            }

            return replies;
        }

        internal static string[] GetAllGategoryNames()
        {
            var forumData = new ForumData();

            var allCategoryNames = forumData.Categories
                .Select(c => c.Name)
                .ToArray();

            return allCategoryNames;
        }
    }
}