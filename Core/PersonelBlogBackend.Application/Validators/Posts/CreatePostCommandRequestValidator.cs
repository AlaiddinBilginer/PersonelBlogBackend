using FluentValidation;
using PersonelBlogBackend.Application.Features.Posts.Commands.CreatePost;

namespace PersonelBlogBackend.Application.Validators.Posts
{
    public class CreatePostCommandRequestValidator : AbstractValidator<CreatePostCommandRequest>
    {
        public CreatePostCommandRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }
}
