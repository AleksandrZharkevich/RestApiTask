using KasperskyTask.Utils.DataManager;
using RestApiTask.Models;
using RestApiTask.Utils.Rest;
using System.Collections.Generic;

namespace RestApiTask.Utils
{
    class ApplicationRequest
    {
        private static IDataReader _reader = new JsonDataReader(Constants.TestDataPath);

        public static (List<Post> Posts, int StatusCod, string ContentType) GetAllPosts()
        {
            Request request = new Request(_reader.ReadProperty<string>("base_url"), _reader.ReadProperty<string>("get_posts_resource"));
            Response<List<Post>> response = APIUtils.Get<List<Post>>(request);
            return (response.Data, (int)response.StatusCode, response.ContentType);
        }

        public static (Post Post, int StatusCode) GetPostById(int id)
        {
            Request request = new Request(_reader.ReadProperty<string>("base_url"), _reader.ReadProperty<string>($"get_post{id}_resource"));
            Response<Post> response = APIUtils.Get<Post>(request);
            return (response.Data, (int)response.StatusCode);
        }

        public static (Post Post, int StatusCode) PostNewPost(object post)
        {
            Request request = new Request(_reader.ReadProperty<string>("base_url"), _reader.ReadProperty<string>("post_newpost_resource"));
            Response<Post> response = APIUtils.Post<Post>(request, post);
            return (response.Data, (int)response.StatusCode);
        }

        public static (List<User> Users, int StatusCod, string ContentType) GetAllUsers()
        {
            Request request = new Request(_reader.ReadProperty<string>("base_url"), _reader.ReadProperty<string>("get_users_resource"));
            Response<List<User>> response = APIUtils.Get<List<User>>(request);
            return (response.Data, (int)response.StatusCode, response.ContentType);
        }

        public static (User User, int StatusCode) GetUserById(int id)
        {
            Request request = new Request(_reader.ReadProperty<string>("base_url"), _reader.ReadProperty<string>($"get_user{id}_resource"));
            Response<User> response = APIUtils.Get<User>(request);
            return (response.Data, (int)response.StatusCode);
        }
    }
}
