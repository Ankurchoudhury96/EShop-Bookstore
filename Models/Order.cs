using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class Order
    {
        [Key]
        public int Orderid { get; set; }
        public string? Productname { get; set; }

        public int? Productid { get; set; } 
        public string? Useremail { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateofPurchase { get; set; }
    }
}
