using System.ComponentModel.DataAnnotations;

namespace SendGridAPI.DataLayer.Models
{
    public class CustomFileds
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

    }
}
