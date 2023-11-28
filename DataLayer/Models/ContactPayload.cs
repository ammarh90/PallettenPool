using Newtonsoft.Json;

namespace SendGridAPI.DataLayer.Models
{
    public class ContactPayload
    {
        public ContactPayload(List<Contact> contacts)
        {
            Contacts = contacts;
        }

        public List<Contact> Contacts { get; set; }
        [JsonProperty("list_ids")]
        public List<string> IdList { get; set; }
    }
}
