using AutoMapper;
using BLL;
using ENTITIES.Context;
using ENTITIES.DTOs;
using ENTITIES.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;


namespace WebApiBloggingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // Dependency Injection - DI
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }


        // Get list of posts
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var listPostsDTO = await _postService.GetPostsService();
            return Ok(listPostsDTO);
        }

        // Get posts by Id
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var postDTO = await _postService.GetPostByIdService(Id);
            if (postDTO == null)
                return NotFound();
            return Ok(postDTO);
        }

        // Add post
        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            await _postService.AddPostService(post);
            return Ok("Post added successfully");
        }

        // Update post
        [HttpPut]
        public async Task<IActionResult> Put(Post post)
        {
            await _postService.UpdatePostService(post);
            return Ok("Post updated successfully");
        }

        // Delete post
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _postService.DeletePostService(Id);
            return Ok("Post deleted successfully.");
        }

    }
}
