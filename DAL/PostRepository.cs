using ENTITIES.Context;
using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 1) Create an interface to define the methods that the concrete class bellow must implement.
    public interface IPostRepository
    {
        Task<List<Post>> GetPostsRepo();
        Task<Post> GetPostByIdRepo(int Id);
        Task AddPostRepo(Post post);
        Task UpdatePostRepo(Post post);
        Task DeletePostRepo(int Id);
    }


    // 2) Implement the concrete class bellow that inherits this interface.
    // With that, the external classes that directly depend on this concrete class will depend only on the generic interface above.
    // Now the Dependency Injection come to the scene! :)  Instead the external classes create an instance of this concrete class bellow,
    // this "dependency" will be injected through contructors!
    // Advantage example: In the future, I can use 'PostRepositoryNewVersion' : IPostRepository. And I won't need to change anything else on the dependent classes.
    public class PostRepository : IPostRepository
    {

        // Dependency Injection - DI
        private readonly BloggingPlatformContext _context;
        public PostRepository(BloggingPlatformContext context)
        {
            _context = context;
        }

        //Get all posts (Repo)
        public async Task<List<Post>> GetPostsRepo()
        {
            // This line returns the post including its respective comments
            return await _context.Posts.Include(post => post.Comments).ToListAsync();
            
            // This line bellow does not return the comments when you get the post
            //return await _context.Posts.ToListAsync();
        }

        // Get post by Id (Repo)
        public async Task<Post> GetPostByIdRepo(int Id)
        {
            return await _context.Posts.FindAsync(Id);
        }

        // Add Post (Repo)
        public async Task AddPostRepo(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        // Update Post (Repo)
        public async Task UpdatePostRepo(Post post)
        {
            // Take post entity from my context and state that it has been modified
            // If it was modified, performs SaveChanges
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete Post
        public async Task DeletePostRepo(int Id)
        {
            var post = await _context.Posts.FindAsync(Id);
            _context.Entry(post).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }

   
}
