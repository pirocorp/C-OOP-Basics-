namespace Forum.App.Services
{
    using System.Linq;
    using Controllers;
    using Data;
    using Models;

    public static class UserService
    {
        public static bool TryLoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var forumData = new ForumData();

            var userExists = forumData.Users.Any(x => x.Username == username && x.Password == password);

            return userExists;
        }

        public static SignUpController.SignUpStatus TrySignUpUser(string username, string password)
        {
            var validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SignUpController.SignUpStatus.DetailsError;
            }

            var forumData = new ForumData();

            var userAllreadyExists = forumData.Users.Any(u => u.Username == username);

            if (userAllreadyExists)
            {
                return SignUpController.SignUpStatus.UsernameTakenError;
            }

            var userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            var user = new User(userId, username, password);
            forumData.Users.Add(user);
            forumData.SaveChanges();

            return SignUpController.SignUpStatus.Success;
        }

        internal static User GetUser(int userId)
        {
            var forumData = new ForumData();
            var user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username)
        {
            var forumData = new ForumData();
            var user = forumData.Users.Find(u => u.Username == username);

            return user;
        }
    }
}