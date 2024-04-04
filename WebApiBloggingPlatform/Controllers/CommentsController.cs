using AutoMapper;
using BLL;
using ENTITIES.Context;
using ENTITIES.DTOs;
using ENTITIES.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace WebApiBloggingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        // Dependency Injection - DI
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        // Get list of comments
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var listCommentsDTO = await _commentService.GetCommentsService();
            return Ok(listCommentsDTO);
        }

        // Get comment by Id
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var commentDTO = await _commentService.GetCommentByIdService(Id);
            if (commentDTO == null)
                return NotFound();

            return Ok(commentDTO);
        }

        // Add comment
        [HttpPost]
        public async Task<IActionResult> Comment(Comment comment)
        {
            await _commentService.AddCommentService(comment);
            return Ok("Comment added successfully");
        }

        // Update comment
        [HttpPut] 
        public async Task<IActionResult> Put(Comment comment)
        {
            await _commentService.UpdateCommentService(comment);
            return Ok("Comment updated successfully");
        }

        // Delete comment
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _commentService.DeleteCommentService(Id);
            return Ok("Comment deleted successfully.");
        }
    }
}
