using System.Collections.Generic;
using Framework.Infrastructure;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        List<ArticleViewModel> GetList();
    }
}