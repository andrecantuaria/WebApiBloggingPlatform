using AutoMapper;
using DAL;
using ENTITIES.DTOs;
using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICommentService
    {
        Task<List<CommentDTO>> GetCommentsService();
        Task<CommentDTO> GetCommentByIdService(int Id);
        Task AddCommentService(Comment comment);
        Task UpdateCommentService(Comment comment);
        Task DeleteCommentService(int Id);

    }

    public class CommentService : ICommentService
    {
        // Dependency Injection - DI
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <returns>A list of comment DTOs.</returns> 
        public async Task<List<CommentDTO>> GetCommentsService()
        {
            var comments= await _commentRepository.GetCommentsRepo();
            return _mapper.Map<List<CommentDTO>>(comments);
        }

        /// <summary>
        /// Gets a comment by its ID.
        /// </summary>
        /// <param name="Id">The ID of the comment.</param>
        /// <returns>The corresponding comment DTO.</returns> 
        public async Task<CommentDTO> GetCommentByIdService(int Id)
        {
            var comment = await _commentRepository.GetCommentByIdRepo(Id);
            return _mapper.Map<CommentDTO>(comment);
        }

        /// <summary>
        /// Adds a new commnet.
        /// </summary>
        /// <param name="comment">The comment to be added.</param>  
        public async Task AddCommentService(Comment comment)
        {
            await _commentRepository.AddCommentRepo(comment);
        }

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="comment">The comment to be updated.</param>
        public async Task UpdateCommentService(Comment comment)
        {
            await _commentRepository.UpdateCommentRepo(comment);
        }

        /// <summary>
        /// Deletes a comment by its ID.
        /// </summary>
        /// <param name="Id">The ID of the comment to be deleted.</param>
        public async Task DeleteCommentService(int Id)
        {
            await _commentRepository.DeleteCommentRepo(Id);
        }

    }
}
