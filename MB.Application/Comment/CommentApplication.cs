using System.Collections.Generic;
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

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetCommentBy(id);
            if (comment == null)
                return;

            comment.Confirm();
            _commentRepository.SaveChanges();

        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetCommentBy(id);
            if (comment == null)
                return;

            comment.Cancel();
            _commentRepository.SaveChanges();
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
    }
}