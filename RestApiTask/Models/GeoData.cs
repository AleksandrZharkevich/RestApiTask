using Newtonsoft.Json;

namespace RestApiTask.Models
{
    public class GeoData
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GeoData data &&
                   Lat == data.Lat &&
                   Lng == data.Lng;
        }
    }
}