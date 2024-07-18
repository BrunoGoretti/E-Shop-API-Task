using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Models
{
    public class ReceiptModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double AmountPaid { get; set; }
        public string? ReceiptNumber { get; set; }
    }
}
