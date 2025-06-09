namespace BlogApi.DTOs
{
    public class CreateBlogDto
    {
        public int UserId { get; set; }  // ID người dùng
        public string Title { get; set; }  // Tiêu đề bài viết
        public string Content { get; set; } // Nội dung bài viết
        public string ImageUrl { get; set; } // Đường dẫn ảnh (nếu có)
    }
}
