using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SendGridAPI.Models;

public class Metadata
{
    //[JsonProperty("prev")]
    //[JsonPropertyName("prev")]
    //public string Prev { get; set; }

    [JsonProperty("self")]
    [JsonPropertyName("self")]
    public string Self { get; set; }

    //[JsonProperty("next")]
    //[JsonPropertyName("next")]
    //public string Next { get; set; }

    [JsonProperty("count")]
    [JsonPropertyName("count")]
    public int Count { get; set; }
}