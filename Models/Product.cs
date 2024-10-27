using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Product
    {
        [Key]
        public int? Pid { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public int? Cid { get; set; }
        [NotMapped]
        [MaxLength(50)]
        public string? Category { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        
        public string? Ppic {  get; set; }

        [NotMapped]
        public IFormFile? Pic { get; set; }
        [DataType(DataType.Currency)]
        public int? Price { get; set; }

        [NotMapped]
        public string? Useremail { get; set; }
    }
}
