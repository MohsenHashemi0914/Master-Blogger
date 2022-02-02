using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
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