using System.Text.Json.Serialization;

namespace SendGridAPI.DataLayer.Models.Response
{
    public class ImportContactStatus
    {
        public string TheJobId { get; set; }
        public string Status { get; set; }
        [JsonPropertyName("job_type")]
        public string  JobType { get; set; }
        public Results Result { get; set; }
        public class Results
        {
            [JsonPropertyName("requested_count")]
            public int RequestedCount  {get; set; }
            [JsonPropertyName("created_count")]

            public int CreatedCount { get; set; }
            [JsonPropertyName("updated_count")]
            public int UpdatedCount{ get; set; }
            [JsonPropertyName("deleted_count")]

            public int DeletedCount { get; set; }
            [JsonPropertyName("errored_count")]

            public int ErroredCount { get; set; }
        }

        public string startAt { get; set; }
        public string FinishedAt { get; set; }
    }
}
