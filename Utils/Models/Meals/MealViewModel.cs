using Newtonsoft.Json;

namespace Utils.Models.Meals
{
    public class IdNameJsonModel
    {
        [JsonProperty("id")]
        public int? MealId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}