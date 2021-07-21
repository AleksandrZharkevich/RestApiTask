using Newtonsoft.Json;

namespace RestApiTask.Models
{
    class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Company company &&
                   Name == company.Name &&
                   CatchPhrase == company.CatchPhrase &&
                   Bs == company.Bs;
        }
    }
}
