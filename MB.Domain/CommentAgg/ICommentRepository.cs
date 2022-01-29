namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void SaveChanges();
        void Add(Comment entity);
        Comment GetCommentBy(long id);
    }
}