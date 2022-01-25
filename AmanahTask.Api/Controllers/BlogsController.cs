using AmanahTask.Api.DTOs;
using AmanahTask.Core;
using AmanahTask.Core.Constants;
using AmanahTask.Core.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.IO;

namespace AmanahTask.Api.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        /// <summary>
        /// Service to Get Add Blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                IEnumerable<Blog> blogs = await _unitOfWork.Blogs.GetAllAsync();
                IEnumerable<BlogDto> blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogs);
                return Ok(blogsDto);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Service to Get All blogs sorted by recent creation date 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBlogsOrderedByDate")]
        public async Task<IActionResult> GetAllBlogsOrderedByDate() 
        {
            try
            {
                IEnumerable<Blog> blogs = await _unitOfWork.Blogs.FindAllAsync( b => true, a=>a.CreationDate,OrderBy.Descending);
                IEnumerable<BlogDto> blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogs);
                return Ok(blogsDto);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Service to Get One Blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBlogById")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                Blog blog = await _unitOfWork.Blogs.GetByIdAsync(id);
                BlogDto blogDto = _mapper.Map<BlogDto>(blog);
                return Ok(blogDto);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To add one Blog
        /// </summary>
        /// <param name="blogDto"></param>
        /// <returns></returns>
        [HttpPost("AddBlog")]
        public async Task<IActionResult> AddBlog(BlogDto blogDto)
        {
            try
            {
                if (blogDto == null)
                    return BadRequest();

                Blog blog = _mapper.Map<Blog>(blogDto);
                var entity = await _unitOfWork.Blogs.AddAsync(blog);
                _unitOfWork.Save();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To update/edit Blog
        /// </summary>
        /// <param name="blogDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateBlog")]
        public IActionResult UpdateBlog(BlogDto blogDto)
        {
            try
            {
                if (blogDto == null)
                    return BadRequest();

                // also you can check on all properties in your model by using ModelState.
                //if (!ModelState.IsValid)
                //    return BadRequest();

                Blog blog = _mapper.Map<Blog>(blogDto);
                var entity = _unitOfWork.Blogs.Update(blog);
                _unitOfWork.Save();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To Delete One Blog by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteBlog")]
        public IActionResult DeleteBlog(int id)
        {
            try
            {
                Blog blog = _unitOfWork.Blogs.Delete(id);
                _unitOfWork.Save();
                return Ok(blog);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return BadRequest(ex.Message);
            }
        }
    }
}
