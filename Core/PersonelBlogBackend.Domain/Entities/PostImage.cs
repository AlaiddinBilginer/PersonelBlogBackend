using PersonelBlogBackend.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelBlogBackend.Domain.Entities
{
    public class PostImage : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }

        public Post Post { get; set; }
        public Guid PostId { get; set; }

        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
