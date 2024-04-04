using DAL;
using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using ENTITIES.DTOs;

namespace BLL
{
    //interface
    public interface IPostService
    {
        Task<List<PostDTO>> GetPostsService();
        Task<PostDTO> GetPostByIdService(int Id);
        Task AddPostService(Post post);
        Task UpdatePostService(Post post);
        Task DeletePostService(int Id);

    }

    public class PostService : IPostService
    {
        // Dependency Injection - DI
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>A list of post DTOs.</returns> 
        public async Task<List<PostDTO>> GetPostsService()
        {
            var posts = await _postRepository.GetPostsRepo();
            return _mapper.Map<List<PostDTO>>(posts);
        }

        /// <summary>
        /// Gets a post by its ID.
        /// </summary>
        /// <param name="Id">The ID of the post.</param>
        /// <returns>The corresponding post DTO.</returns> 
        public async Task<PostDTO> GetPostByIdService(int Id)
        {
            var post = await _postRepository.GetPostByIdRepo(Id);
            return _mapper.Map<PostDTO>(post);
        }

        /// <summary>
        /// Adds a new post.
        /// </summary>
        /// <param name="post">The post to be added.</param> 
        public async Task AddPostService(Post post)
        {
            await _postRepository.AddPostRepo(post);
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="post">The post to be updated.</param>
        public async Task UpdatePostService(Post post)
        {
            await _postRepository.UpdatePostRepo(post);
        }

        /// <summary>
        /// Deletes a post by its ID.
        /// </summary>
        /// <param name="Id">The ID of the post to be deleted.</param>
        public async Task DeletePostService(int Id)
        {
            await _postRepository.DeletePostRepo(Id);
        }

    }

   
}


