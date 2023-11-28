using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SendGridAPI.Models;

public class MarketingListDto
{
    [Required]
    [MaxLength(255)]
    [JsonPropertyName("name")]
    public string Name { get; set; }
}