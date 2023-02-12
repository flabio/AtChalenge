using AtChalenge.Core.Entities;
using AtChalenge.Core.Interfaces;

namespace AtChalenge.Core.Services
{
    public class CommentService :ICommentService
    {
        private readonly ICommentRepository _CommentRepository;
        public CommentService(ICommentRepository CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _CommentRepository.GetComment(id);
        }

        public async Task<IEnumerable<Comment>> GetComments(int idMovie)
        {
            return await _CommentRepository.GetComments(idMovie);
        }

        public async Task<bool> CreateComment(Comment comment)
        {

            return await _CommentRepository.CreateComment(comment);
        }

        public async Task<bool> UpdateComment(int id, Comment comment)
        {
            return await _CommentRepository.UpdateComment(id, comment);
        }
        public async Task<bool> DeleteComment(int id)
        {
            return await _CommentRepository.DeleteComment(id);
        }

        #region
        //method private


        #endregion
    }
}
