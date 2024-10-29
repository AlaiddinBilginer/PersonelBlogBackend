using FluentValidation;
using PersonelBlogBackend.Application.Features.Tags.Commands.CreateTag;

namespace PersonelBlogBackend.Application.Validators.Tags
{
    public class CreateTagCommandRequestValidator : AbstractValidator<CreateTagCommandRequest>
    {
        public CreateTagCommandRequestValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();

            RuleFor(x => x.Tags)
                .NotEmpty().WithMessage("En az 1 tane etiket eklemelisiniz.")
                .Must(x => x.Count <= 10).WithMessage("En fazla 10 etiket ekleyebilirsiniz.");
        }
    }
}
