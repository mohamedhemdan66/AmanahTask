using AmanahTask.Api.DTOs;
using AmanahTask.Core.Constants;
using AmanahTask.Core.Domain;
using AmanahTask.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmanahTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepo;
        private readonly IMapper _mapper;

        public BlogsController(IBlogRepository blogRepo, IMapper mapper)
        {
            this._blogRepo = blogRepo;
            this._mapper = mapper;
        }

        /// <summary>
        ///  Get All Blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {

            var blogs = await _blogRepo.GetAllAsync();
            var data = _mapper.Map<IEnumerable<BlogDto>>(blogs);
            return Ok(data); 
        }

        /// <summary>
        /// Get All Blogs Orderd recently by creationDate
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBlogsOrderd")]
        public async Task<IActionResult> GetAllBlogsOrderd()
        {
            var blogs = await _blogRepo.GetAllAsync( b=>b.CreationDate, OrderBy.Descending);
            var data = _mapper.Map<IEnumerable<BlogDto>>(blogs);
            return Ok(data);
        }

        /// <summary>
        /// Get Blog ById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBlogById/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogRepo.GetByIdAsync(id);
            if (blog == null)
                NotFound();

            var data = _mapper.Map<BlogDto>(blog);
            return Ok(data);
        }

        /// <summary>
        /// Create Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BlogDto blog) 
        {
            var entity = _mapper.Map<Blog>(blog);
            return Ok(await _blogRepo.AddAsync(entity));
        }

        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update(BlogDto blog)
        {
            var entity = _mapper.Map<Blog>(blog);
            return Ok(_blogRepo.Update(entity));
        }

        /// <summary>
        /// Delete by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_blogRepo.Delete(id));
        }

    }
}
