using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Application.ViewModels.Posts;
using PersonelBlogBackend.Domain.Entities;
using System.Net;

namespace PersonelBlogBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;

        public PostsController(
            IPostReadRepository postReadRepository, 
            IPostWriteRepository postWriteRepository
        )
        {
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postReadRepository.GetAll(false);

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _postReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VMCreatePost model)
        {
            await _postWriteRepository.AddAsync(new()
            {
                Title = model.Title,
                Content = model.Content,
            });

            await _postWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(VMUpdatePost model)
        {
            Post post = await _postReadRepository.GetByIdAsync(model.Id);
            post.Title = model.Title;
            post.Content = model.Content;
            await _postWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _postWriteRepository.DeleteByIdAsync(id);
            await _postWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
