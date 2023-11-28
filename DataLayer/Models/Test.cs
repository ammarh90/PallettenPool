using Newtonsoft.Json;

namespace SendGridAPI.DataLayer.Models
{
    public class Test
    {
        [JsonProperty("job_id")]
        public string Id { get; set; }
    }
}
