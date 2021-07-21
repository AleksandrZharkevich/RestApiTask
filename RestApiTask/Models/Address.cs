using Newtonsoft.Json;

namespace RestApiTask.Models
{
    class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("suite")]
        public string Suite { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
        [JsonProperty("geo")]
        public GeoData Geo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Street == address.Street &&
                   Suite == address.Suite &&
                   City == address.City &&
                   Zipcode == address.Zipcode &&
                   Geo.Equals(address.Geo);
        }
    }
}
