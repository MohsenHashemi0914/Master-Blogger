using System.Collections.Generic;
using System.Linq;
using Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        #region constructor

        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        #endregion
    }
}