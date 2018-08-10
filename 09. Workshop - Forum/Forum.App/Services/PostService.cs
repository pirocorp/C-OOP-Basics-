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

            foreach (var replayId in post.ReplyIds)
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

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var forumData = new ForumData();
            var postIds = forumData.Categories.First(c => c.Id == categoryId).PostsIds;
            var posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            var forumData = new ForumData();

            var post = forumData.Posts.Find(p => p.Id == postId);

            var postViewModel = new PostViewModel(post);

            return postViewModel;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            var category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);

            if (category == null)
            {
                var categories = forumData.Categories;
                var categoryId = categories.Any() ? categories.Last().Id + 1: 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            var emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            var emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            var emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            var forumData = new ForumData();
            var category = EnsureCategory(postView, forumData);

            var posts = forumData.Posts;
            var postId = posts.Any() ? posts.Last().Id + 1 : 1;

            var author = UserService.GetUser(postView.Author);

            var authorId = author.Id;
            var content = string.Join(string.Empty, postView.Content);

            var post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostsIds.Add(post.Id);

            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyView, int postId)
        {
            if (!replyView.Content.Any())
            {
                return false;
            }

            ForumData forumData = new ForumData();
            var replies = forumData.Replies;
            int replyId = replies.Any() ? replies.Last().Id + 1 : 1;
            Post post = forumData.Posts.First(p => p.Id == postId);
            User author = UserService.GetUser(replyView.Author);
            int authorId = author.Id;

            string content = String.Join("", replyView.Content);
            Reply reply = new Reply(replyId, content, authorId, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();
            return true;
        }
    }
}