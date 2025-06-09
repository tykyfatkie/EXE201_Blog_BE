namespace BlogApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }   // ID người dùng
        public string Username { get; set; } // Tên người dùng
        public DateTime CreatedAt { get; set; } // Thời gian tạo tài khoản
    }
}
