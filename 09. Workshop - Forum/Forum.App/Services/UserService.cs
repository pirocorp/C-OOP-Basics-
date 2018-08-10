namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

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

        public static bool TrySignUpUser(string username, string password)
        {

        }
    }
}