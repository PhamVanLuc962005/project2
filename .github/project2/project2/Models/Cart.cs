using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project2.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
