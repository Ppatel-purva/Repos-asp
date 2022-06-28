using Newtonsoft.Json;

namespace cosmosdb.Models
{
    public class Item
    {
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName= "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "discriotion")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "iscompleted")]
        public string Completed { get; set; }


    }
}
