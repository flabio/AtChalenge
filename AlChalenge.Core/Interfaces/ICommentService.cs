using AtChalenge.Core.Entities;

namespace AtChalenge.Core.Interfaces
{
    public interface ICommentService
    {
        Task<bool> CreateComment(Comment comment);
        Task<bool> DeleteComment(int id);
        Task<Comment> GetComment(int id);
        Task<IEnumerable<Comment>> GetComments(int idMovie);
        Task<bool> UpdateComment(int id, Comment comment);
    }
}