using Newtonsoft.Json;

namespace RestApiTask.Models
{
    class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("company")]
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Username == user.Username &&
                   Email == user.Email &&
                   Address.Equals(user.Address) &&
                   Phone == user.Phone &&
                   Website == user.Website &&
                   Company.Equals(user.Company);
        }
    }
}
