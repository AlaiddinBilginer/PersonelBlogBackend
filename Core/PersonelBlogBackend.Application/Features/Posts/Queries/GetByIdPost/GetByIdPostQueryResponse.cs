using PersonelBlogBackend.Application.DTOs.Comments;
using PersonelBlogBackend.Application.DTOs.PostImages;
using PersonelBlogBackend.Application.DTOs.Tags;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetByIdPost
{
    public class GetByIdPostQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<TagDto> Tags { get; set; }
        public ICollection<PostImageDto> PostImages { get; set; }
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
