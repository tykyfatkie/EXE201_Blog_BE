using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models
{
    public class Blog
    {
        public int Id { get; set; }  // ID tự tăng
        [Required]
        public int UserId { get; set; }  // Khóa ngoại tới bảng User
        public User User { get; set; }    // Điều hướng tới đối tượng User
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string? ImageUrl { get; set; }  // Đổi thành nullable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Thời gian tạo
    }
}
