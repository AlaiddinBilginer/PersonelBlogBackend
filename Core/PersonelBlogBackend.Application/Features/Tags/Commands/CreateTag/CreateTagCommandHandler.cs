using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;

namespace PersonelBlogBackend.Application.Features.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagCommandResponse>
    {
        private readonly ITagWriteRepository _tagWriteRepository;
        private readonly ITagReadRepository _tagReadRepository;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;

        public CreateTagCommandHandler(ITagWriteRepository tagWriteRepository, ITagReadRepository tagReadRepository, IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository)
        {
            _tagWriteRepository = tagWriteRepository;
            _tagReadRepository = tagReadRepository;
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        public async Task<CreateTagCommandResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            Post? post = await _postReadRepository
                .GetWhere(p => p.Id == Guid.Parse(request.PostId))
                .Include(p => p.Tags)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return new CreateTagCommandErrorResponse() { Message = "Blog bulunamadı" };
            }

            HashSet<Tag> existingPostTags = post.Tags.ToHashSet();
            HashSet<string> tagTitles = request.Tags.ToHashSet();

            foreach (var tagTitle in tagTitles)
            {
                var existingTag = await _tagReadRepository.GetWhere(t => t.Title == tagTitle).FirstOrDefaultAsync();
                if(existingTag == null)
                {
                    existingTag = new Tag() { Title = tagTitle };
                    await _tagWriteRepository.AddAsync(existingTag);
                    await _tagWriteRepository.SaveAsync();
                }

                
                existingPostTags.Add(existingTag);
            }

            if(existingPostTags.Count > 10)
            {
                return new CreateTagCommandErrorResponse() { Message = "Bir bloğun en fazla 10 adet etiketi olabilir" };
            }

            post.Tags = existingPostTags;
            await _postWriteRepository.SaveAsync();

            return new CreateTagCommandSuccessResponse() { Message = "Etiket ekleme işlemi başarılı"};
        }
    }
}
