using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class Registration
    {

        [Required]
        [MaxLength(100)]
        public string? Uname { get; set; }

        [Key]
        [DataType(DataType.EmailAddress)] 
        public required string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password don't match.")]
        public string? ConfirmPassword { get; set; }

    }
}
