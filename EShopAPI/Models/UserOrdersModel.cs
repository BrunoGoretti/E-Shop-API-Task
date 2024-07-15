using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Models
{
    public class Usermodel
    {
        [Key]
        public int UserId { get; set; }
        public int OrderNumber { get; set; }
        public double PayableAmount { get; set; }
        public string PaymentGateway { get; set; }
        public string OptionalDescription { get; set; }
    }
}
