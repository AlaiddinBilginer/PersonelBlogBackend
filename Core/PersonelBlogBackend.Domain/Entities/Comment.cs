using PersonelBlogBackend.Domain.Entities.Common;
using PersonelBlogBackend.Domain.Entities.Identity;

namespace PersonelBlogBackend.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public Guid? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public ICollection<Comment> Replies { get; set; }
    }
}
