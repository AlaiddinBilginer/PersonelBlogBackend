using FluentValidation;
using PersonelBlogBackend.Application.Features.Comments.Commands.UpdateComment;

namespace PersonelBlogBackend.Application.Validators.Comments
{
    public class UpdateCommentCommandRequestValidator : AbstractValidator<UpdateCommentCommandRequest>
    {
        public UpdateCommentCommandRequestValidator()
        {
            RuleFor(x => x.CommentId).NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Yorum içeriği boş olamaz.")
                .MaximumLength(500).WithMessage("Yorum içeriği en fazla 500 karakter olmalıdır.");
        }
    }
}
