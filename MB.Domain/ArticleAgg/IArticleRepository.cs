using System.Collections.Generic;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        void SaveChanges();
        void Add(Article entity);
        Article GetBy(long id);
        List<ArticleViewModel> GetList();
    }
}