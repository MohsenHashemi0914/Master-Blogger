using System.Collections.Generic;
using System.Linq;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        #region constructor

        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        #endregion

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Add(ArticleCategory entity)
        {
            _context.Add(entity);
        }

        public bool IsArticleCategoryTitleExist(string title)
        {
            return _context.ArticleCategories
                .Any(x => x.Title.ToUpper().Trim() == title.ToUpper().Trim());
        }

        public ArticleCategory GetBy(long id)
        {
            return _context.ArticleCategories.Find(id);
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }
    }
}