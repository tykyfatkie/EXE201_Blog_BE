namespace BlogApi.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }     // ID bài viết
        public string Title { get; set; }  // Tiêu đề bài viết
        public string Content { get; set; } // Nội dung bài viết
        public string ImageUrl { get; set; } // Đường dẫn tới ảnh (nếu có)
        public DateTime CreatedAt { get; set; } // Thời gian tạo bài viết

        // Thông tin người dùng liên quan
        public UserDto User { get; set; }
    }
}
