using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void SaveChanges();
        void Add(ArticleCategory entity);
        bool IsArticleCategoryTitleExist(string title);
        ArticleCategory GetBy(long id);
        List<ArticleCategory> GetAll();
    }
}