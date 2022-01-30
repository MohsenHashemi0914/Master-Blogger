using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

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

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    Email = x.Email,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Article = x.Article.Title,
                    Status = x.Status
                }).OrderByDescending(x => x.Id).ToList();
        }
    }
}