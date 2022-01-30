using System.Collections.Generic;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment command);
        void Confirm(long id);
        void Cancel(long id);
        List<CommentViewModel> GetList();
    }
}