using ENTITIES.Context;
using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsRepo();
        Task<Comment> GetCommentByIdRepo(int Id);
        Task AddCommentRepo(Comment comment);
        Task UpdateCommentRepo(Comment comment);
        Task DeleteCommentRepo(int Id);

    }


    public class CommentRepository : ICommentRepository
    {

        // Dependency Injection - DI
        private readonly BloggingPlatformContext _context;
        public CommentRepository(BloggingPlatformContext context)
        {
            _context = context;
        }

        //Get all comments (Repo)
        public async Task<List<Comment>> GetCommentsRepo()
        {
            return await _context.Comments.ToListAsync();
        }

        // Get comment by Id (Repo)
        public async Task<Comment> GetCommentByIdRepo(int Id)
        {
            return await _context.Comments.FindAsync(Id);
        }

        // Add comment (Repo)
        public async Task AddCommentRepo(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        // Update comment (Repo)
        public async Task UpdateCommentRepo(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete comment
        public async Task DeleteCommentRepo(int Id)
        {
            var comment = await _context.Comments.FindAsync(Id);
            _context.Entry(comment).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }
}
