using Newtonsoft.Json;

namespace RestApiTask.Models
{
    class Post
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }

        public bool IsEmpty()
        {
            return UserId == 0 && Id == 0 && Title == null && Body == null;
        }
    }
}
