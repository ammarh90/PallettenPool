using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SendGridAPI.DataLayer.Models
{
    public class SingleSendDto
    {
        //    [MaxLength(100), MinLength(1)]
        //    public string Name { get; set; }
        //    public List<string> Categories { get; set; }

        //    [JsonPropertyName("send_at")]
        //    public string SendAt { get; set; }
        //    [JsonPropertyName("send_to")]
        //    public SendTo SendTo { get; set; }
        //    public EmailConfig EmailConfig { get; set; }
        //    public List<Warnings> Warnings { get; set; }

        //}
        //public class SendTo
        //{
        //    [JsonPropertyName("list_ids")]
        //    public List<string> ListIds{ get; set; }
        //}

        //public class EmailConfig
        //{
        //    public string Subject { get; set; }
        //    [JsonPropertyName("design_id")]
        //    public string DesignId { get; set; }
        //    [JsonPropertyName("sender_id")]
        //    public int SenderId { get; set; }
        //    public string Id { get; set; }
        //    public string Status { get; set; }
        //    [JsonPropertyName("updated_at")]
        //    public string UpdatedAt{ get; set; }
        //    [JsonPropertyName("created_at")]
        //    public string CreatedAt { get; set; }
        //}

        //public class Errors
        //{
        //    public string Message { get; set; }
        //    public string Field { get; set; }
        //    [JsonPropertyName("error_id")]
        //    public string error_id { get; set; }
        //}


        public class EmailConfig
        {
            public string subject { get; set; }
            //public string html_content { get; set; }
            //public string plain_content { get; set; }
            //public bool generate_plain_content { get; set; }
            public string Editor { get; set; }
            [JsonPropertyName("suppression_group_id")]
            public object SuppressionGroupId { get; set; }
            [JsonPropertyName("custom_unsubscribe_url")]
            public object CustomUnsubscribeUrl { get; set; }
            [JsonPropertyName("sender_id")]
            public int SenderId { get; set; }
            [JsonPropertyName("ip_pool")]
            public object IpPool { get; set; }
        }

        public class Root
        {
            [MaxLength(100), MinLength(1)]
            public string Name { get; set; }
            public string Id { get; set; }
            public string status { get; set; }
            [JsonPropertyName("created_at")]
            public DateTime CreatedAt { get; set; }
            [JsonPropertyName("sender_at")]
            public DateTime SendAt { get; set; }
            public List<string> Categories { get; set; }
            [JsonPropertyName("email_config")]
            public EmailConfig EmailConfig { get; set; }
            [JsonPropertyName("send_to")]
            public SendTo SendTo { get; set; }
        }

        public class SendTo
        {
            public List<string> list_ids { get; set; }
        }
        public class Errors
        {
            public string Message { get; set; }
            public string Field { get; set; }
            [JsonPropertyName("error_id")]
            public string error_id { get; set; }
        }
    }
}