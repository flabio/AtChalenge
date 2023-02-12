using AtChalenge.Core.Entities;
using AtChalenge.Core.Interfaces;
using AtChalenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AtChalenge.Infrastructure.Repositories
{
    public class CommentRepository :ICommentRepository
    {

        private readonly AtChalengeContext _context;
        public CommentRepository(AtChalengeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetComments(int idMovie)
        {
            try
            {
                var results = await _context.Comments.Where(x=>x.IsActive==true && x.IdMovie== idMovie).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> CreateComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                var row = await _context.SaveChangesAsync();
                return row > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Comment> GetComment(int id)
        {
            try
            {
                var result = await _context.Comments.Where(x => x.IsActive == true).FirstOrDefaultAsync(x=>x.IdComment==id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateComment(int id, Comment comment)
        {
            try
            {
                var currentComment = await GetComment(id);
                if (currentComment != null)
                {
                    currentComment.Descrption = comment.Descrption;
                    var row = await _context.SaveChangesAsync();
                    return row > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteComment(int id)
        {
            try
            {
                var currentComment = await GetComment(id);
                if (currentComment != null)
                {
                    currentComment.IsActive = false;
                    var row = await _context.SaveChangesAsync();
                    return row > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}