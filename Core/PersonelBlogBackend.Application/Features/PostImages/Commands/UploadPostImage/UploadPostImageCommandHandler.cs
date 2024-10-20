using MediatR;
using PersonelBlogBackend.Application.Abstractions.Storage;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;

namespace PersonelBlogBackend.Application.Features.PostImages.Commands.UploadPostImage
{
    public class UploadPostImageCommandHandler : IRequestHandler<UploadPostImageCommandRequest, UploadPostImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IPostImageWriteRepository _postImageWriteRepository;

        public UploadPostImageCommandHandler(IStorageService storageService, IPostImageWriteRepository postImageWriteRepository)
        {
            _storageService = storageService;
            _postImageWriteRepository = postImageWriteRepository;
        }

        public async Task<UploadPostImageCommandResponse> Handle(UploadPostImageCommandRequest request, CancellationToken cancellationToken)
        {
            var datas = await _storageService.UploadAsync("resource/post-images", request.Files);
            await _postImageWriteRepository.AddRangeAsync(datas.Select(d => new PostImage()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());
            await _postImageWriteRepository.SaveAsync();
            return new UploadPostImageCommandResponse() { Succeeded = true, Message = "Resimler başarılı bir şekilde yüklendi" };
        }
    }
}
