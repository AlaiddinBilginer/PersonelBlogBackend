using FluentValidation;
using PersonelBlogBackend.Application.Features.Comments.Commands.AddComment;

namespace PersonelBlogBackend.Application.Validators.Comments
{
    public class AddCommentCommandRequestValidator : AbstractValidator<AddCommentCommandRequest>
    {
        public AddCommentCommandRequestValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Yorum içeriği boş olamaz.")
                .MaximumLength(500).WithMessage("Yorum içeriği en fazla 500 karakter olmalıdır.");
        }
    }
}
