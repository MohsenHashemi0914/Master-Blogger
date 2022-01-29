using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        #region constructor

        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Add(Comment entity)
        {
            _context.Add(entity);
        }

        public Comment GetCommentBy(long id)
        {
            return _context.Comments.Find(id);
        }
    }
}