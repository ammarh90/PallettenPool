using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SendGridAPI.Models;

public class Root
{
    [JsonProperty("result")]
    [JsonPropertyName("result")]
    public List<Result> Result { get; set; }

    [JsonProperty("_metadata")]
    [JsonPropertyName("_metadata")]
    public Metadata Metadata { get; set; }
}