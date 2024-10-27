using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class Useraddress
    {
        [Key]
        public required string UName { get; set; }
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string? Addressline1 { get; set; }
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string? Addressline2 { get; set; }

        [MaxLength(200)]
        public string? State { get; set; }
        public int? Mobileno { get; set; }
    }
}
