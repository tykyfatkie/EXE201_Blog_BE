using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models
{
    public class User
    {
        public int Id { get; set; }  // ID tự tăng
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Thời gian tạo
    }
}
