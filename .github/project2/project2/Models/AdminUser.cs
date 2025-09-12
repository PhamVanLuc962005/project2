using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project2.Models
{
    public class AdminUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
