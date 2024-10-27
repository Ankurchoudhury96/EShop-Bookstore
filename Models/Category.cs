using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        [MaxLength(100)]
        public string? CategoryName {  get; set; }
    }
}
