using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SendGridAPI.DataLayer.Models
{
    public class Contact
    {
        //[Required]
        [MaxLength(50)]
        [JsonPropertyName("first_name")]
        public string Name { get; set; }
        //[Required]
        [MaxLength(50)]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string Email { get; set; }
        //[Required]
        [JsonPropertyName("address_line_1")]
        public string AddressLine { get; set; }
        //[Required]
        public string City { get; set; }
        [JsonPropertyName("postal_code")]
        //[Required]
        public string PostalCode { get; set; }
        //[Required]
        public string Country { get; set; }

        [JsonPropertyName("state_province_region")] 
        public string StateProvinceRegion { get; set; }


        //public CustomFileds Custom_field { get; set; }
    }
}
