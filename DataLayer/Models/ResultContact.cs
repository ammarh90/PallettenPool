using Newtonsoft.Json;

namespace SendGridAPI.DataLayer.Models
{
    public class ResultContact
    {

        public class CustomFields
        {
        }

        public class Metadata
        {
            public string self { get; set; }
        }

        public class Result
        {
            [JsonProperty("address_line_1")]

            public string address_line_1 { get; set; }
            [JsonProperty("address_line_2")]

            public string address_line_2 { get; set; }
            [JsonProperty("alternate_emails")]

            public object AlternateEmails { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string email { get; set; }
            [JsonProperty("first_name")]
            public string firstName { get; set; }
            public string id { get; set; }
            [JsonProperty("last_name")]

            public string last_name { get; set; }
            [JsonProperty("list_ids")]

            public List<string> list_ids { get; set; }
            [JsonProperty("postal_code")]

            public string PostalCode { get; set; }
            [JsonProperty("state_province_region")]

            public string StateProvinceRegion { get; set; }
            [JsonProperty("phone_number")]

            public string PhoneNumber { get; set; }
            //public string whatsapp { get; set; }
            //public string line { get; set; }
            //public string facebook { get; set; }
            //public string unique_name { get; set; }
            [JsonProperty("_metadata")]

            public Metadata Metadata { get; set; }
            [JsonProperty("custom_fields")]

            public CustomFields CustomFields { get; set; }
            [JsonProperty("created_at")]

            public DateTime CreatedAt { get; set; }
            [JsonProperty("updated_at")]

            public string UpdatedAt { get; set; }
        }

        public class Root
        {
            public List<Result> result { get; set; }
            [JsonProperty("contact_count")]

            public int ContactCount { get; set; }
            [JsonProperty("_metadata")]

            public Metadata _metadata { get; set; }
        }
    }
}
