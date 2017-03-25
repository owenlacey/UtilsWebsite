using Newtonsoft.Json;

namespace Utils.Models.Shared
{
    public class IdNameJsonModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}