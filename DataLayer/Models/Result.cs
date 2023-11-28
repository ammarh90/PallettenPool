using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SendGridAPI.Models;

public class Result
{

    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonProperty("contact_count")]
    [JsonPropertyName("contact_count")]
    public int ContactCount { get; set; }

    [JsonProperty("_metadata")]
    [JsonPropertyName("_metadata")]
    public Metadata Metadata { get; set; }


    public class ContactSample
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
}