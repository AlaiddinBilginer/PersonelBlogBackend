namespace PersonelBlogBackend.Application.DTOs.Comments
{
    public class CommentListDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
