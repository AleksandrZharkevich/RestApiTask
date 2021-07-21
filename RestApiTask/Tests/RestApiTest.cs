using KasperskyTask.Utils.DataManager;
using NUnit.Framework;
using RestApiTask.Models;
using RestApiTask.Utils;
using System.Linq;

namespace RestApiTask.Tests
{
    [TestFixture]
    public class RestApiTest
    {
        [Test]
        public void Test1()
        {
            IDataReader reader = new JsonDataReader(Constants.TestDataPath);
            var posts = ApplicationRequest.GetAllPosts();
            Assert.AreEqual(reader.ReadProperty<int>("get_posts_statuscode"), posts.StatusCod, "Status code is not correct");
            Assert.True(posts.ContentType.Contains(reader.ReadProperty<string>("content_type")), "Not Json is returned");
            Assert.That(posts.Posts, Is.Ordered.By(reader.ReadProperty<string>("get_posts_sortkey")), "Collection is not ordered coorectly");

            int post99Id = reader.ReadProperty<int>("get_post99_id");
            var post99 = ApplicationRequest.GetPostById(post99Id);
            Assert.AreEqual(reader.ReadProperty<int>("get_post99_statuscode"), post99.StatusCode, "Status code is not correct");
            Assert.AreEqual(post99Id, post99.Post.Id, "Id is not correct");
            Assert.AreEqual(reader.ReadProperty<int>("get_post99_userid"), post99.Post.UserId, "User id is not correct");
            Assert.IsNotEmpty(post99.Post.Title, "Title is empty");
            Assert.IsNotEmpty(post99.Post.Body, "Body is empty");

            var post150 = ApplicationRequest.GetPostById(reader.ReadProperty<int>("get_post150_id"));
            Assert.AreEqual(reader.ReadProperty<int>("get_post150_statuscode"), post150.StatusCode, "Status code is not correct code is not correct");
            Assert.True(post150.Post.IsEmpty(), "Not empty object is returned");

            var newPost = new
            {
                Title = RandomStringGenerator.RandomString(10),
                Body = RandomStringGenerator.RandomString(10),
                UserId = reader.ReadProperty<int>("post_newpost_userid")
            };
            var insertedPost = ApplicationRequest.PostNewPost(newPost);
            Assert.AreEqual(reader.ReadProperty<int>("post_newpost_statuscode"), insertedPost.StatusCode, "Status code is not correct");
            Assert.True(newPost.Body == insertedPost.Post.Body && newPost.Title == insertedPost.Post.Title
                && newPost.UserId == insertedPost.Post.UserId, "Fields are not equal");
            Assert.That(insertedPost.Post.Id, Is.GreaterThan(0), "Id is absent (set in default value)");

            var users = ApplicationRequest.GetAllUsers();
            Assert.AreEqual(reader.ReadProperty<int>("get_users_statuscode"), users.StatusCod, "Status code is not correct");
            Assert.True(users.ContentType.Contains(reader.ReadProperty<string>("content_type")), "Not Json is returned");
            int user5Id = reader.ReadProperty<int>("get_user5_id");
            User user5 = users.Users.Where(user => user.Id == user5Id).Single();
            Assert.AreEqual(user5, reader.ReadProperty<User>("user5"), "Users are not equal");

            var user5new = ApplicationRequest.GetUserById(user5Id);
            Assert.AreEqual(reader.ReadProperty<int>("get_user5_statuscode"), user5new.StatusCode, "Status code is not correct");
            Assert.AreEqual(user5, user5new.User, "Users are not equal");
        }
    }
}