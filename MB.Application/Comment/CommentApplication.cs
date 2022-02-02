using System.Collections.Generic;
using Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application.Comment
{
    public class CommentApplication : ICommentApplication
    {
        #region constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public void Add(AddComment command)
        {
            _unitOfWork.BeginTran();
            var comment = new Domain.CommentAgg.Comment(command.Name,
                command.Message,
                command.Email,
                command.ArticleId);
           
            _commentRepository.Add(comment);
            _unitOfWork.CommitTran();
        }

        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();

            var comment = _commentRepository.GetBy(id);
            if (comment == null)
                return;

            comment.Confirm();
            _unitOfWork.CommitTran();

        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();

            var comment = _commentRepository.GetBy(id);
            if (comment == null)
                return;

            comment.Cancel();
            _unitOfWork.CommitTran();
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
    }
}