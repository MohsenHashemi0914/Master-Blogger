using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                    Image = x.Image
                }).OrderByDescending(x => x.Id).ToList();
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            if (comments != null && comments.Any())
            {
                return comments.Select(x => new CommentQueryView
                {
                    Name = x.Name,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            }

            return new List<CommentQueryView>();
        }

        public ArticleQueryView GetArticleBy(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    Content = x.Content,
                    CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                    Comments = MapComments(x.Comments.Where(z => z.Status == Statuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }
    }
}