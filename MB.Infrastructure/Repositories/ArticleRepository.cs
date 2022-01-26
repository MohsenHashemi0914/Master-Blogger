using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        #region constructor

        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Add(Article entity)
        {
            _context.Add(entity);
        }

        public Article GetBy(long id)
        {
            return _context.Articles.Find(id);
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory = x.ArticleCategory.Title
                }).ToList();
        }
    }
}