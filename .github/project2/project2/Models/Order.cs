using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project2.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}