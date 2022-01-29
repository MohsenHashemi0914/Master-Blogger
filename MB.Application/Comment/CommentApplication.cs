using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application.Comment
{
    public class CommentApplication : ICommentApplication
    {
        #region constructor

        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        #endregion

        public void Add(AddComment command)
        {
            var comment = new Domain.CommentAgg.Comment(command.Name,
                command.Message,
                command.Email,
                command.ArticleId);
           
            _commentRepository.Add(comment);
            _commentRepository.SaveChanges();
        }
    }
}