using System.Collections.Generic;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void SaveChanges();
        void Add(Comment entity);
        Comment GetCommentBy(long id);
        List<CommentViewModel> GetList();
    }
}