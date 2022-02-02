using Framework.Infrastructure;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
    }
}